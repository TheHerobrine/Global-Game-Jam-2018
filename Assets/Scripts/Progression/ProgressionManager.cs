using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[System.Serializable]
[CreateAssetMenu(fileName = "Progression Manager", menuName = "Progression Manager")]
public class ProgressionManager : ScriptableObject
{
    [System.Serializable]
    public class ProgressionStep
    {
        public string name;
        public bool reached;
        public int order;
    }

    public ProgressionStep[] progressionSteps;
    public ProgressionManager()
    {
        progressionSteps = new ProgressionStep[0];
    }

    public bool StepReached(string key)
    {
        return progressionSteps.Any(s => s.name == key) &&
            progressionSteps.First(s => s.name == key).reached;
    }

    public bool OrderCompleted(int order)
    {
        return progressionSteps
            .Where(s => s.order == order && !s.reached)
            .ToArray()
            .Length == 0;
    }

    public ProgressionStep StepAt(string key)
    {
        return progressionSteps.First(s => s.name == key);
    }
}
