using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WolrdController : MonoBehaviour
{
    [Range(1,4)]
    public int _zoneNumber;

    public GameObject[] _firstZone;
    public GameObject[] _secondZone;
    public GameObject[] _thirdZone;
    public GameObject[] _fourthZone;

    public string[] _varNames;

    private void Start()
    {
        for (int i = 0; i < _varNames.Length; i++)
        {
            if(i == _zoneNumber - 1)
            {
                ShowController((GameObject[])this.GetType().GetField(_varNames[i]).GetValue(this));
            }
            else
            {
                HideController((GameObject[])this.GetType().GetField(_varNames[i]).GetValue(this));
            }
        }
    }

    private void Update() //luego pasar a fixed update
    {
        for (int i = 0; i < _varNames.Length; i++)
        {
            if (i == _zoneNumber - 1)
            {
                ShowController((GameObject[])this.GetType().GetField(_varNames[i]).GetValue(this));
            }
            else
            {
                HideController((GameObject[])this.GetType().GetField(_varNames[i]).GetValue(this));
            }
        }
    }

    void ShowController(GameObject[] _zone)
    {
        for (int i = 0; i < _zone.Length; i++)
        {
            _zone[i].SetActive(true);
        }
    }
    void HideController(GameObject[] _lastZone)
    {
        for (int i = 0; i < _lastZone.Length; i++)
        {
            _lastZone[i].SetActive(false);
        }
    }
}
