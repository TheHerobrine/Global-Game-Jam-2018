#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ProgressionManager))]
public class ProgressionManagerInspector : Editor
{
    private ProgressionManager manager;

    public void OnEnable()
    {
        manager = (ProgressionManager)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Step name", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Order", EditorStyles.boldLabel, GUILayout.Width(40f));
        EditorGUILayout.LabelField("Reached", EditorStyles.boldLabel, GUILayout.Width(45));
        EditorGUILayout.EndHorizontal();

        for(int i = 0; i < manager.progressionSteps.Length; i++)
        {
            EditorGUILayout.BeginHorizontal();
            manager.progressionSteps[i].name = EditorGUILayout.TextField(manager.progressionSteps[i].name);
            manager.progressionSteps[i].order = EditorGUILayout.IntField(manager.progressionSteps[i].order, GUILayout.Width(40f));
            manager.progressionSteps[i].reached = EditorGUILayout.Toggle(manager.progressionSteps[i].reached, GUILayout.Width(20f));
            if (GUILayout.Button("X", GUILayout.Width(20f)))
            {
                ProgressionManager.ProgressionStep[] temp = manager.progressionSteps;
                manager.progressionSteps = new ProgressionManager.ProgressionStep[temp.Length - 1];
                for(int j = 0; j < i; j++)
                    manager.progressionSteps[j] = temp[j];
                for (int j = i + 1; j < temp.Length; j++)
                    manager.progressionSteps[j - 1] = temp[j];
                break;
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add a progression key"))
        {
            Array.Resize(ref manager.progressionSteps, manager.progressionSteps.Length + 1);
            manager.progressionSteps[manager.progressionSteps.Length - 1] = new ProgressionManager.ProgressionStep {
                name = "DEFAULT_KEY",
                reached = false,
                order = 0
            };
            Repaint();
        }

        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }
}
#endif
