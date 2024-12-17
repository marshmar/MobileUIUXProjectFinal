#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.UI;
using System.Reflection;

// ScaledToggle���� scale�� time ���� �ν����� â�� ���� ���� ������
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
        // Toggle �⺻ �ʵ� ���� �׸���
        base.OnInspectorGUI();

        // �߰� Ŀ���� �ʵ� �׸���
        EditorGUILayout.Space();
        serializedObject.Update();

        EditorGUILayout.LabelField("Scale Toggle Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(scaleProperty, new GUIContent("Scale"));
        EditorGUILayout.PropertyField(timeProperty, new GUIContent("Time"));


        serializedObject.ApplyModifiedProperties();
    }
}
#endif