using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] TMP_Text Text_Depth;
    [SerializeField] TMP_Text Text_Rope;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Bait bait = GameController.Instance.Bait;
        Text_Depth.text = $"Depth: {(bait?.Depth ?? 0).ToString("0.00")} m";
        Text_Rope.text = $"Rope: {(bait?.RopeLeft ?? 0).ToString("0.00")} m";
    }
}