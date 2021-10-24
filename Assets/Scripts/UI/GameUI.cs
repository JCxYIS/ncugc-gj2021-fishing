using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

public class GameUI : MonoBehaviour
{
    [SerializeField] TMP_Text Text_Depth;
    [SerializeField] TMP_Text Text_Rope;
    [SerializeField] TMP_Text Text_Money;
    [SerializeField] CanvasGroup BtnContainer;
    [SerializeField] Button Btn_Shop;
    [SerializeField] Button Btn_DropTheBait;
    [SerializeField] Button Btn_Settings;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        // Btn_Shop
        Btn_DropTheBait.onClick.AddListener(()=>GameController.Instance.Player.DropTheBait());
        // Btn_Settings.onClick.a // this is binded in editor :D
        Btn_DropTheBait.transform
            .DOScale(Vector3.one * 1.2f, 0.48763f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Bait bait = GameController.Instance.Bait;
        Text_Depth.text = $"Depth: {(bait?.Depth ?? 0).ToString("0.00")} m";
        Text_Rope.text = $"Rope: {(bait?.RopeLeft ?? 0).ToString("0.00")} m";
        Text_Money.text = $"<sprite name=\"coinIcon\"> {GameManager.Money.ToString("0")}";

        switch(GameController.Instance.GameState)
        {
            case GameController.State.Idle:
                BtnContainer.DOFade(1, 0.48763f);
                break;
            default:
                BtnContainer.DOFade(0, 0.1f);
                break;
        }
    }
}