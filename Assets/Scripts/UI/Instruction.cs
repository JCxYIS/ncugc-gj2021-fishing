using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Instruction : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField] RectTransform mousePic;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();   
        canvasGroup.alpha = 0; 
        mousePic
            .DOAnchorPosX(71, 1f)
            .From(new Vector2(-71, mousePic.anchoredPosition.y))
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);    
    }

    public void StartShow()
    {
        StopAllCoroutines();
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        canvasGroup.alpha = 1;
        // mousePic.anchoredPosition = new Vector2(-71, mousePic.anchoredPosition.y);
        
        yield return new WaitForSeconds(2.5f);
        canvasGroup.DOFade(0, 0.39f);
    }
}
