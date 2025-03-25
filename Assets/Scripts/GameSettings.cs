using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/Settings")]
public class GameSettings : ScriptableObject
{
    public GameObject[] shapePrefabs;
    public Material trailMaterial;
    public Color currentColor = Color.white;
    [Range(0, 3)] public int currentShapeIndex = 0;
    public float swipeThreshold = 150f;
}