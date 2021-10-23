using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public enum State { Idle, ThrowBait, Fishing, FishHooked, Hook };

    private State state = State.Idle;
    public State GameState => state;

    public Player Player;
    public Bait Bait;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 30;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
    }

    public void ChangeState(State newState)
    {
        state = newState;
    }
}