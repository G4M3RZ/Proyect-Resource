using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgacharseYCorrer : MonoBehaviour
{
    private PlayerController _playerController;
    private Pausa _pausa;
    private float _playerSpeed;
    public CapsuleCollider _body;
    [Range(0,1)]
    public float _yNewPos;

    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _pausa = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Pausa>();
        _playerSpeed = _playerController._bodySpeed;
    }
    void Update()
    {
        if (!_pausa._pause)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Vector3 _newPos = new Vector3(0, -_yNewPos, 0);
                _playerController._bodySpeed = _playerSpeed / 2;
                _body.height = _yNewPos;
                _body.center = new Vector3(0, -0.5f, 0);
                transform.localPosition = Vector3.Lerp(transform.localPosition, _newPos, Time.deltaTime * 5);
            }
            else if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
            {
                Vector3 _normalPos = new Vector3(0, 0, 0);
                _playerController._bodySpeed = _playerSpeed * 2;
                _body.height = 2;
                _body.center = new Vector3(0, 0, 0);
                transform.localPosition = Vector3.Lerp(transform.localPosition, _normalPos, Time.deltaTime * 5);
            }
            else
            {
                Vector3 _normalPos = new Vector3(0, 0, 0);
                _playerController._bodySpeed = _playerSpeed;
                _body.height = 2;
                _body.center = new Vector3(0, 0, 0);
                transform.localPosition = Vector3.Lerp(transform.localPosition, _normalPos, Time.deltaTime * 5);
            }
        }
    }
}
