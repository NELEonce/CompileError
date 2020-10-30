using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public sealed class PlayerInspector : Editor
{
    private SerializedProperty characterHeight;

    private void OnEnable()
    {
        characterHeight = serializedObject.FindProperty("characterHeight");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.indentLevel = 0;
        //EditorUtilities.FoldoutHeader("Character Settings", characterHeight);

        EditorGUI.indentLevel = 1;
        

        EditorGUILayout.PropertyField(characterHeight, new UnityEngine.GUIContent("Height (m)"));

        serializedObject.ApplyModifiedProperties();
    }
}
