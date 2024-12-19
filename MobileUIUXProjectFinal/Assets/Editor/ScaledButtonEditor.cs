#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(ScaledButton))]
public class ScaledButtonEditor : SelectableEditor
{
    SerializedProperty scaleProperty;
    SerializedProperty timeProperty;
    SerializedProperty onClickProperty;

    protected override void OnEnable()
    {
        base.OnEnable();
        scaleProperty = serializedObject.FindProperty("scale");
        timeProperty = serializedObject.FindProperty("time");
        onClickProperty = serializedObject.FindProperty("m_OnClick");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();

        serializedObject.Update();

        EditorGUILayout.LabelField("Scale Button Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(scaleProperty, new GUIContent("Scale"));
        EditorGUILayout.PropertyField(timeProperty, new GUIContent("Time"));
        EditorGUILayout.PropertyField(onClickProperty, new GUIContent("On Click"));

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
