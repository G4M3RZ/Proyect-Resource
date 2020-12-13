using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;

    [Range(0,5)]
    public float _normalSpeed, _highSpeed;

    private FieldOfView _vista;
    private NavMeshAgent _navMesh;

    public bool _followPlayer;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _vista = GetComponent<FieldOfView>();
        _navMesh = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (_followPlayer)
        {
            _navMesh.speed = _highSpeed;
            if (Vector3.Distance(_player.transform.position, transform.position) < 2)
            {
                _navMesh.isStopped = true;
            }
            else
            {
                _navMesh.isStopped = false;
                _navMesh.SetDestination(_vista._findPlayerPos);
            }
        }
        else
        {
            _navMesh.speed = _normalSpeed;
        }
    }
}
