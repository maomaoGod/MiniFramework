using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(DrawComponent)),CanEditMultipleObjects]
public class DrawEditor : Editor
{
    private SerializedProperty patterns;
    private DrawComponent dc;
    private void OnEnable()
    {
        patterns = serializedObject.FindProperty("Patterns");
        dc = (DrawComponent)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        // 自定义绘制
        if (GUILayout.Button("Add"))
        {
            dc.Patterns.Add(new Pattern());
        }
        if (GUILayout.Button("Delete"))
        {
            if (dc.Patterns.Count > 0)
            {
                dc.Patterns.Remove(dc.Patterns[dc.Patterns.Count - 1]);
            }            
        }
        EditorGUILayout.PropertyField(patterns,true);
        serializedObject.ApplyModifiedProperties();
    }
}
