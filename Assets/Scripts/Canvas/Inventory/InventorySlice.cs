using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlice : MonoBehaviour
{
    public bool _backPack;
    public bool _inventario;
    private bool _lock;

    private GameObject _mainCam;
    private Pausa _pausa;
    private PlayerController _player;
    public RectTransform _menuPause;

    public float _limit = 512f;
    public float _speed;
    private float _normalSpeedCam;

    private float _startInvPos;

    private void Start()
    {
        _inventario = _backPack = false;
        _pausa = GetComponent<Pausa>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        _startInvPos = _menuPause.localPosition.x;
        _normalSpeedCam = _player._camSpeed;
    }

    private void Update()
    {
        SliceInventory();

        if (!_backPack)
        {
            GetBackPack();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _inventario = !_inventario;
            _lock = true;
        }
    }
    void SliceInventory()
    {
        if(_backPack == true)
        {
            if (_inventario && !_pausa._pause)
            {
                Vector3 _newPos = new Vector3(_startInvPos - _limit, 0, 0);
                _menuPause.localPosition = Vector3.Lerp(_menuPause.localPosition, _newPos, Time.deltaTime * _speed);

                if (_lock)
                {
                    Cursor.visible = true;
                    _player._camSpeed = 0;
                    _lock = false;
                }
            }
            else
            {
                Vector3 _newPos = new Vector3(_startInvPos, 0, 0);
                _menuPause.localPosition = Vector3.Lerp(_menuPause.localPosition, _newPos, Time.deltaTime * _speed);

                if (_lock)
                {
                    Cursor.visible = false;
                    _player._camSpeed = _normalSpeedCam;
                    _lock = false;
                }
            }
        }
    }

    void GetBackPack()
    {
        Ray ray = new Ray(_mainCam.transform.position, _mainCam.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            if (Input.GetMouseButtonDown(0) && hitInfo.collider.CompareTag("BackPack"))
            {
                _backPack = true;
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }
}
