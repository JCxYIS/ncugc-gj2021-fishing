using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    Animator animator;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        switch(GameController.Instance.GameState)
        {
            case GameController.State.Idle:
                if(Input.GetMouseButtonDown(0))
                {
                    StartCoroutine(ThrowBaitAnim());
                }
                break;

            case GameController.State.Fishing:
                break;

            case GameController.State.FishHooked:
                break;
        }
    }

    IEnumerator ThrowBaitAnim()
    {
        GameController.Instance.ChangeState(GameController.State.ThrowBait);
        animator.Play("ThrowBait");

        yield return new WaitForSeconds(.7f);    
        print("Baited");

        GameController.Instance.ChangeState(GameController.State.Fishing);
        animator.Play("Fishing");
    }
}