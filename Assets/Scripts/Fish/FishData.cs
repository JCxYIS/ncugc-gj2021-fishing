using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// [CreateAssetMenu(fileName = "FishData", menuName = "ScriptableObject/FishData")]
[System.Serializable]
public class FishData //: ScriptableObject
{
    [Header("Basic")]
    public int Score;
    public float Rareness; // this value is the avg of specified fish spawn count in each game
    
    [Header("Spawn at depth")]
    public int MinDepth;
    public int MaxDepth;

    [Header("Behavior")]
    public float SwimSpeed;
    public float FollowSpeedMultiplier;
    public bool FollowBait;
    public bool AvoidBait;
}