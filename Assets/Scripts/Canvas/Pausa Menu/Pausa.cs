using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    private PlayerController _player;

    public GameObject _menu;

    public bool _pause, _mainMenu;
    private bool _lock;
    private float _camSpeed, _bodySpeed;

    private void Start()
    {
        Cursor.visible = false;
        _pause = _lock = false;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _camSpeed = _player._camSpeed;
        _bodySpeed = _player._bodySpeed;
    }

    void Update()
    {
        PausaController();
        MainMenuController();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pause = !_pause;
            _lock = true;
        }
    }

    void PausaController()
    {
        #region Pausa
        if (_pause && _lock)
        {
            Cursor.visible = true;
            _player._camSpeed = 0f;
            _player._bodySpeed = 0f;

            _menu.SetActive(true);

            Time.timeScale = 0f;

            _lock = false;
        }
        else if (!_pause && _lock)
        {
            Cursor.visible = false;
            _player._camSpeed = _camSpeed;
            _player._bodySpeed = _bodySpeed;

            _menu.SetActive(false);

            Time.timeScale = 1f;

            _lock = false;
        }
        #endregion
    }
    void MainMenuController()
    {
        #region MainMenu
        if (_mainMenu)
        {

        }
        #endregion
    }

    #region ButtonsControllers
    public void Resume()
    {
        Cursor.visible = false;
        _player._camSpeed = _camSpeed;
        _player._bodySpeed = _bodySpeed;

        _menu.SetActive(false);

        Time.timeScale = 1f;

        _pause = false;
    }

    public void MainMenu()
    {
        _mainMenu = true;

        Time.timeScale = 1f;
    }
    #endregion
}