using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject _headController;
    private CharacterController _player;
    public float _camSpeed;
    public float _bodySpeed;
    private float _gravity, _fallVelocity;

    private float _xAxisClmap;
    private float h,v;

    private Vector3 _playerInput, _movePlayer, _camForward, _camRight;

    void Start()
    {
        _xAxisClmap = 0.0f;
        _gravity = Physics.gravity.y;
        _player = GetComponent<CharacterController>();
    }

    void Update()
    {
        #region RotarCuerpoYCamara
        //Rotar Curpo
        h = _camSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
        //Rotar Camara
        v = _camSpeed * Input.GetAxis("Mouse Y");
        _headController.transform.Rotate(-v, 0, 0);
        #endregion

        #region LimitarRotacionCamara
        _xAxisClmap += v;
        if(_xAxisClmap > 90.0f)
        {
            _xAxisClmap = 90.0f;
            v = 0.0f;
            ClampXAxisRotation(270.0f);
        }
        else if (_xAxisClmap < -90.0f)
        {
            _xAxisClmap = -90.0f;
            v = 0.0f;
            ClampXAxisRotation(90.0f);
        }
        #endregion

        #region MovimientoPlayer
        float _h,_v;
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        _playerInput = new Vector3(_h, 0, _v);
        _playerInput = Vector3.ClampMagnitude(_playerInput, 1);

        GetCamDirection();

        _movePlayer = _playerInput.x * _camRight + _playerInput.z * _camForward;
        _movePlayer = _movePlayer * _bodySpeed;

        SetGravity();

        _player.Move(_movePlayer * Time.deltaTime);
        #endregion
    }
    private void ClampXAxisRotation(float value)
    {
        Vector3 eulerRotation = _headController.transform.eulerAngles;
        eulerRotation.x = value;
        _headController.transform.eulerAngles = eulerRotation;
    }
    void GetCamDirection()
    {
        _camForward = _headController.transform.forward;
        _camRight = _headController.transform.right;

        _camForward.y = 0;
        _camRight.y = 0;

        _camForward = _camForward.normalized;
        _camRight = _camRight.normalized;
    }
    void SetGravity()
    {
        if (_player.isGrounded)
        {
            _fallVelocity = _gravity * Time.deltaTime;
            _movePlayer.y = _fallVelocity;
        }
        else
        {
            _fallVelocity += _gravity * Time.deltaTime;
            _movePlayer.y = _fallVelocity;
        }
    }
}