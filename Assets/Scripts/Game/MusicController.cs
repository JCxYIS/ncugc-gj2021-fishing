using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource AudioSource;
    public AudioClip SFX_StartFishing;
    public AudioClip SFX_CaughtFish;
    public AudioClip SFX_GetFish;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySfx(AudioClip sfx)
    {
        AudioSource.PlayOneShot(sfx);
    }
}
