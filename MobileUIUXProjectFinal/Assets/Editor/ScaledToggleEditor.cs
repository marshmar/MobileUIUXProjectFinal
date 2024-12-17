#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.UI;
using System.Reflection;

// ScaledToggle에서 scale과 time 값을 인스펙터 창에 띄우기 위한 에디터
[CustomEditor(typeof(ScaledToggle))]
public class ScaledToggleEditor : ToggleEditor
{
    SerializedProperty scaleProperty;
    SerializedProperty timeProperty;


    protected override void OnEnable()
    {
        base.OnEnable();
        scaleProperty = serializedObject.FindProperty("scale");
        timeProperty = serializedObject.FindProperty("time");
    }

    public override void OnInspectorGUI()
    {
        // Toggle 기본 필드 먼저 그리기
        base.OnInspectorGUI();

        // 추가 커스텀 필드 그리기
        EditorGUILayout.Space();
        serializedObject.Update();

        EditorGUILayout.LabelField("Scale Toggle Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(scaleProperty, new GUIContent("Scale"));
        EditorGUILayout.PropertyField(timeProperty, new GUIContent("Time"));


        serializedObject.ApplyModifiedProperties();
    }
}
#endif