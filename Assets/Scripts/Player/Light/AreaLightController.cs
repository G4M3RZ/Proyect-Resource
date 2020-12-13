using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLightController : MonoBehaviour
{
    public Light _luz;
    
    [HideInInspector]
    public float _LightInt;

    private int _lightIntensity;
    public bool _isRaining;
    private bool _lock;

    private void Start()
    {
        _lock = _isRaining = false;
    }
    private void Update()
    {
        LightNormal();
        RainController();
    }
    void LightNormal()
    {
        if (!_isRaining)
        {
            _luz.intensity = (_luz.intensity < _LightInt) ? _luz.intensity += Time.deltaTime * 10 : _luz.intensity = _LightInt;
        }
    }
    void RainController()
    {
        if (_isRaining && !_lock)
        {
            StartCoroutine("RainDistorisionArea");
            _lock = true;
        }
    }
    IEnumerator RainDistorisionArea()
    {
        while (_isRaining)
        {
            _lightIntensity = Random.Range(5, 35);
            _luz.intensity = _lightIntensity;
            yield return new WaitForSeconds(0.1f);
        }

        if (!_isRaining)
        {
            _lock = false;
            StopCoroutine("RainDistorisionArea");
        }
    }
}
