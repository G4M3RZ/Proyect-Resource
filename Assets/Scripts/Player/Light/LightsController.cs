using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour
{
    public List<GameObject> _lights;
    private int _lightNum;
    private bool _enable;

    private void Awake()
    {
        for (int i = 0; i < _lights.Count; i++)
            _lights[i].SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TurnLights();

        if (Input.GetKeyDown(KeyCode.R) && _enable)
            SwipeLights();
    }
    private void TurnLights()
    {
        _enable = !_enable;
        _lights[_lightNum].SetActive(_enable);
    }
    private void SwipeLights()
    {
        _lightNum = (_lightNum == 0) ? 1 : 0;

        for (int i = 0; i < _lights.Count; i++)
        {
            if (i == _lightNum)
                _lights[i].SetActive(true);
            else
                _lights[i].SetActive(false);
        }
    }
}