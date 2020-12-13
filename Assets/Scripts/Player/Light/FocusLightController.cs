using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusLightController : MonoBehaviour
{
    public Light _luz;

    [HideInInspector]
    public float _LightInt;

    private int _lightIntensity;
    public bool _isRainingMan;
    private bool _lock;

    private void Start()
    {
        _lock = _isRainingMan = false;
    }
    private void Update()
    {
        LightNormal();
        RainController();
    }
    void LightNormal()
    {
        if (!_isRainingMan)
        {
            _luz.intensity = (_luz.intensity < _LightInt) ? _luz.intensity += Time.deltaTime * 10 : _luz.intensity = _LightInt;
        }
    }
    void RainController()
    {
        if (_isRainingMan && !_lock)
        {
            StartCoroutine("RainDistorisionLight");
            _lock = true;
        }
    }
    IEnumerator RainDistorisionLight()
    {
        while(_isRainingMan)
        {
            _lightIntensity = Random.Range(5, 35);
            _luz.intensity = _lightIntensity;
            yield return new WaitForSeconds(0.1f);
        }

        if (!_isRainingMan)
        {
            _lock = false;
            StopCoroutine("RainDistorisionLight");
        }
    }
}
