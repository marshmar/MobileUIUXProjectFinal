#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(HoldingComponent))]
public class HoldingComponentEditor : SelectableEditor
{
    SerializedProperty scaleProperty;
    SerializedProperty timeProperty;
    SerializedProperty onClickProperty;
    SerializedProperty holdingTimeProperty;
    SerializedProperty imageProperty;

    protected override void OnEnable()
    {
        base.OnEnable();
        scaleProperty = serializedObject.FindProperty("scale");
        timeProperty = serializedObject.FindProperty("time");
        holdingTimeProperty = serializedObject.FindProperty("holdingTime");
        imageProperty = serializedObject.FindProperty("enableImage");
        onClickProperty = serializedObject.FindProperty("m_OnClick");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();

        serializedObject.Update();

        EditorGUILayout.LabelField("Holding Button Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(scaleProperty, new GUIContent("Scale"));
        EditorGUILayout.PropertyField(timeProperty, new GUIContent("Time"));
        EditorGUILayout.PropertyField(holdingTimeProperty, new GUIContent("HoldingTime"));
        EditorGUILayout.PropertyField(imageProperty, new GUIContent("EnableImage"));
        EditorGUILayout.PropertyField(onClickProperty, new GUIContent("On Click"));

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
