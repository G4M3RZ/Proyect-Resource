using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour
{
    public float _viewRadius;
    [Range(0, 360)]
    public float _viewAngle;

    public LayerMask _targetMask;
    public LayerMask _obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public float _meshResolution;

    [HideInInspector]
    public Vector3 _findPlayerPos;
    [HideInInspector]
    public EnemyNearYou _player;
    private EnemyMovement _moves;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<EnemyNearYou>();
        StartCoroutine("FindTargetsWithDelay", 0.2f);
        _moves = GetComponent<EnemyMovement>();
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    private void Update()
    {
        DrawFieldOfWiev();
    }
    void FindVisibleTargets()
    {
        _moves._followPlayer = false;

        visibleTargets.Clear();
        Collider[] targetsInViewRadious = Physics.OverlapSphere(transform.position, _viewRadius, _targetMask);

        for (int i = 0; i < targetsInViewRadious.Length; i++)
        {
            Transform target = targetsInViewRadious[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < _viewAngle / 2)
            {
                float disToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, disToTarget, _obstacleMask))
                {
                    visibleTargets.Add(target);
                    _findPlayerPos = target.position;
                    _moves._followPlayer = true;
                    _player._isFollowed = true;
                }
            }
            else
            {
                _moves._followPlayer = false;
                _player._isFollowed = false;
            }
        }
    }
    void DrawFieldOfWiev()
    {
        int stepCount = Mathf.RoundToInt(_viewAngle * _meshResolution);
        float stepAngleSize = _viewAngle / stepCount;

        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - _viewAngle / 2 + stepAngleSize * i;
            Debug.DrawLine(transform.position, transform.position + DirFromAngle(angle, true) * _viewRadius, Color.red);
        }
    }

    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;

        if(Physics.Raycast(transform.position, dir, out hit, _viewRadius, _obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * _viewRadius, _viewRadius, globalAngle);
        }
    }

    public Vector3 DirFromAngle(float _angleInDegress, bool _angleIsGlobal)
    {
        if (!_angleIsGlobal)
        {
            _angleInDegress += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(_angleInDegress * Mathf.Deg2Rad), 0, Mathf.Cos(_angleInDegress * Mathf.Deg2Rad));
    }
    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
}
