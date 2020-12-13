using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public List<GameObject> _views;
    private int _quality, _brightness;

    private void Awake()
    {
        ChangeViews(0);
    }
    private void ChangeViews(int activeValue)
    {
        for (int i = 0; i < _views.Count; i++)
        {
            bool active = (i == activeValue) ? true : false;
            _views[i].SetActive(active);
        }
    }

    public void SettingsOption(int viewNumber)
    {
        ChangeViews(viewNumber);
    }
    public void Quallity(Slider quality)
    {
        _quality = (int)quality.value;
    }
    public void Brightness(Slider brightness)
    {
        _brightness = (int)brightness.value;
    }
    public void SaveSettings()
    {
        QualitySettings.SetQualityLevel(_quality);
    }
}