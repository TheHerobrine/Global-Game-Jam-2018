using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Environment Manager", menuName = "Environment Manager")]
public class EnvironmentManager : ScriptableObject
{
    public bool outside = false;
}
