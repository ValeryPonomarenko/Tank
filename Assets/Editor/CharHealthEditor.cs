using Character;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof (CharHealth))]
public class CharHealthEditor : Editor
{
    private SerializedProperty shieldProp;
    private SerializedProperty healthProp;

    private void OnEnable()
    {
        shieldProp = serializedObject.FindProperty("Shield");
        healthProp = serializedObject.FindProperty("Health");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(healthProp, new GUIContent("Health"));

        EditorGUILayout.Slider(shieldProp, 0f, 1.0f, new GUIContent("Shield"));
        ProgressBar(shieldProp.floatValue, string.Format("Shield {0}%", shieldProp.floatValue*100f));
        shieldProp.floatValue = 1.0f - shieldProp.floatValue;

        serializedObject.ApplyModifiedProperties();
    }

    private void ProgressBar(float value, string lable)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, lable);
        EditorGUILayout.Space();
    }
}