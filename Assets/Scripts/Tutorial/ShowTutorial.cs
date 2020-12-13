using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTutorial : MonoBehaviour
{
    public TextMeshPro[] _textosTutorial;

    private float _alfa;

    private int _numText;
    private bool _thisText;

    private void Start()
    {
        _alfa = _numText = 0;

        _thisText = true;

        for (int i = 0; i < _textosTutorial.Length; i++)
        {
            _textosTutorial[i].color = new Color(1, 1, 1, _alfa);
        }
    }

    private void Update()
    {
        switch (_numText)
        {
            case 0: _textosTutorial[0].color = new Color(1, 1, 1, _alfa); break;
            case 1: _textosTutorial[1].color = new Color(1, 1, 1, _alfa); break;
            case 2: _textosTutorial[2].color = new Color(1, 1, 1, _alfa); break;
            case 3: _textosTutorial[3].color = new Color(1, 1, 1, _alfa); break;
            default: Destroy(this.gameObject); break;
        }
        if (_thisText)
        {
            if(_alfa < 0.7f)
            {
                _alfa += Time.deltaTime / 4f;
            }
            else
            {
                _thisText = false;
            }
        }
        else
        {
            if(_alfa > 0)
            {
                _alfa -= Time.deltaTime / 4f;
            }
            else
            {
                _numText++;
                _thisText = true;
            }
        }
    }
}
