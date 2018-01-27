using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestProgression))]
public class TestProgressionInspector : Editor
{
    private TestProgression testProgression;

    public void OnEnable()
    {
        testProgression = (TestProgression)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Test if TEST_KEY is reached"))
        {
            Debug.Log(testProgression.progressionManager.StepReached("TEST_KEY"));
        }
    }
}
