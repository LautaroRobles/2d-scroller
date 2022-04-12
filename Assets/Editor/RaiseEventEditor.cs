using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(VoidEventSO))]
public class RaiseEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        VoidEventSO myGameEvent = (VoidEventSO)target;

        //GUILayout.TextField("asd");

        if (GUILayout.Button("Raise()"))
        {
            myGameEvent.RaiseEvent();
        }
    }
}
