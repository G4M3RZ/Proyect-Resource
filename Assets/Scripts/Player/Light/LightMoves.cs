using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMoves : MonoBehaviour
{
    public GameObject _headController;

    void FixedUpdate()
    {
        #region FocusCam

        transform.localRotation = _headController.transform.localRotation;

        #endregion
    }
}
