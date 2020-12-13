using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject _fadePrefab;
    private bool _fadeInScene;

    [Range(0, 20)]
    public float _camSpeed, _settingPos;
    private Transform _mainCamera;
    private bool _settings;

    public Image _canvasFog;

    private void Awake()
    {
        _fadeInScene = false;
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _canvasFog.color = Color.black;
    }
    private void Update()
    {
        float speed = Time.deltaTime * _camSpeed;

        SettingsPosition(speed);
        SettingsFog(speed * 2);
    }
    private void SettingsPosition(float speed)
    {
        int value = (_settings) ? 1 : 0;
        float pos = value * _settingPos;

        float currentPos = Mathf.Lerp(_mainCamera.position.z, pos, speed);
        _mainCamera.position = new Vector3(0, _mainCamera.position.y, currentPos);
    }
    private void SettingsFog(float speed)
    {
        int alpha = (_settings) ? 0 : 1;

        Color newColor = _canvasFog.color;
        newColor.a = Mathf.Lerp(newColor.a, alpha, speed);

        _canvasFog.color = newColor;
    }

    public void NewSceneInstance(string newSceneName)
    {
        if (!_fadeInScene)
        {
            GameObject instance = Instantiate(_fadePrefab, _mainCamera);
            instance.GetComponent<Fade>()._sceneName = newSceneName;
            _fadeInScene = true;
        }
    }
    public void Settings()
    {
        _settings = !_settings;
    }
}