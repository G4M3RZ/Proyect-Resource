using UnityEngine;

public class EnemyNearYou : MonoBehaviour
{
    private float _darkScare;
    [Range(0,1)]
    public float _darkSpeed;

    public bool _isFollowed;

    void Start()
    {
        _darkScare = 0.2f;
        _isFollowed = false;
    }

    void Update()
    {
        if (_isFollowed)
        {
            _darkScare = (_darkScare < 1) ? _darkScare += Time.deltaTime * _darkSpeed : _darkScare = 1;
        }
        else
        {
            _darkScare = (_darkScare > 0.2f) ? _darkScare -= Time.deltaTime * _darkSpeed : _darkScare = 0.2f;
        }
    }
}