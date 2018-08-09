using UnityEditor;
using UnityEngine;
namespace MiniFramework
{
    [CustomEditor(typeof(DrawComponent)), CanEditMultipleObjects]
    public class DrawEditor : Editor
    {
        private SerializedProperty patterns;
        private SerializedProperty color;
        private void OnEnable()
        {
            patterns = serializedObject.FindProperty("Patterns");
            color = serializedObject.FindProperty("Color");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            if (GUILayout.Button("Add"))
            {
                patterns.arraySize++;
            }
            if (GUILayout.Button("Delete"))
            {
                patterns.arraySize--;
            }
            EditorGUILayout.PropertyField(color);
            for (int i = 0; i < patterns.arraySize; i++)
            {
                SerializedProperty pattern = patterns.GetArrayElementAtIndex(i);
                SerializedProperty type = pattern.FindPropertyRelative("Type");
                EditorGUILayout.PropertyField(type);
                SerializedProperty createMesh = pattern.FindPropertyRelative("CreateMesh");
                EditorGUILayout.PropertyField(createMesh);
                if (type.enumValueIndex == (int)PatternType.圆形)
                {
                    SerializedProperty radius = pattern.FindPropertyRelative("Radius");
                    EditorGUILayout.PropertyField(radius);
                }
                if (type.enumValueIndex == (int)PatternType.扇形)
                {
                    SerializedProperty radius = pattern.FindPropertyRelative("Radius");
                    SerializedProperty angle = pattern.FindPropertyRelative("Angle");
                    EditorGUILayout.PropertyField(radius);
                    EditorGUILayout.PropertyField(angle);
                }
                if (type.enumValueIndex == (int)PatternType.矩形)
                {
                    SerializedProperty length = pattern.FindPropertyRelative("Length");
                    SerializedProperty width = pattern.FindPropertyRelative("Width");
                    EditorGUILayout.PropertyField(length);
                    EditorGUILayout.PropertyField(width);
                }
            }
            serializedObject.ApplyModifiedProperties();
        }
    }

}