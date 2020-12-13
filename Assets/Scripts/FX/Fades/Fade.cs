using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [HideInInspector]
    public string _sceneName;
    private Material _fadeMat;
    private Color _fadeColor;

    private void Start()
    {
        _fadeMat = GetComponent<MeshRenderer>().material;
        
        _fadeColor = Color.black;
        _fadeColor.a = (_sceneName == "") ? 1 : 0;
        _fadeMat.color = _fadeColor;
    }

    private void Update()
    {
        _fadeColor.a = (_sceneName == "") ? _fadeColor.a -= Time.deltaTime : _fadeColor.a += Time.deltaTime;
        _fadeColor.a = Mathf.Clamp(_fadeColor.a, 0, 1);

        _fadeMat.color = _fadeColor;

        if(_fadeColor.a == 1)
        {
            if (_sceneName == "Exit")
                Application.Quit();
            else
                SceneManager.LoadScene(_sceneName);
        }
        else if(_fadeColor.a == 0)
        {
            if (_sceneName == "")
                Destroy(this.gameObject);
        }
    }
}