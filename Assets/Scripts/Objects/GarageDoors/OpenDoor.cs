using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool _isOpen;
    public float _speed;
    private float _numControl;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(_numControl, 0, 0);

        if (_isOpen)
        {
            _numControl = (_numControl < 90) ? _numControl += Time.deltaTime * _speed : _numControl = 90;
        }
        else
        {
            _numControl = (_numControl > 0) ? _numControl -= Time.deltaTime * _speed : _numControl = 0;
        }
    }
}
