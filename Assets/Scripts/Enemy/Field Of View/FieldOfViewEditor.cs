using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof (FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow._viewRadius);
        Vector3 viewAngleA = fow.DirFromAngle(-fow._viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow._viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow._viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow._viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fow.visibleTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
    }
}
