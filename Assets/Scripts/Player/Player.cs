using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    Animator animator;

    public Vector2 _spawnBaitPos;
    public GameObject _baitPrefab;


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

            case GameController.State.TowBack:
                break;
            
            case GameController.State.Hook:
                StartCoroutine(HookAnim());                
                break;

            case GameController.State.Hooking:
                break;
        }
    }

    IEnumerator ThrowBaitAnim()
    {
        GameController.Instance.NextState(GameController.State.ThrowBait);
        animator.Play("ThrowBait");

        yield return new WaitForSeconds(.48763f);    
        print("Baited");

        var bait = Instantiate(_baitPrefab, _spawnBaitPos, Quaternion.identity);
        GameController.Instance.Bait = bait.GetComponent<Bait>();
        GameController.Instance.NextState(GameController.State.Fishing);
        animator.Play("Fishing");
    }

    IEnumerator HookAnim()
    {
        animator.Play("Hook");
        GameController.Instance.NextState( GameController.State.Hooking );
        
        yield return new WaitForSeconds(.48763f);
        
        GameController.Instance.NextState( GameController.State.End);
    }
}