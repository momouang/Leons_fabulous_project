using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ixdScript))]
public class ixdSystemEditor : Editor
{
    // Start is called before the first frame update
    public enum DisplayCategory
    {
        Teleport, Item, Interactable, LockedDoor, DisableAndEnable
    }

    public DisplayCategory categoryToDisplay;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        /*
        categoryToDisplay = (DisplayCategory)EditorGUILayout.EnumPopup("Display", categoryToDisplay);

        EditorGUILayout.Space();
        */
        serializedObject.ApplyModifiedProperties();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
