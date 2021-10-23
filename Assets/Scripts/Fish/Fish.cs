using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fish : MonoBehaviour
{
    public static readonly float BOUNDRY = 6;
    public FishData fishData;
    private bool flipX;

    SpriteRenderer _spriteRenderer;
    

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    IEnumerator Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();


        while(true)
        {
            flipX = Random.value >= 0.5f;
            yield return new WaitForSeconds( Random.Range(2f, 4f) );
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        _spriteRenderer.flipX = flipX;
        transform.position += Vector3.left / 100f * (flipX?1:-1) * fishData.SwimSpeed;
    }


    public void Caught()
    {
        transform.parent = GameController.Instance.Bait.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = flipX ? Quaternion.Euler(0, 0, 310) : Quaternion.Euler(0, 0, 50);
        enabled = false;
    }
}