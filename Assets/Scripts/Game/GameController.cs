using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public enum State { Idle, ThrowBait, Fishing, TowBack, Hook, Hooking, End };

    private State state = State.Idle;
    public State GameState => state;

    public Cinemachine.CinemachineVirtualCamera virtualCamera;    
    public Player Player;
    [HideInInspector] public Bait Bait;
    


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
        switch(state)
        {            
            case State.Fishing:
                virtualCamera.Follow = Bait.transform;
                break;
            case State.End:
                virtualCamera.Follow = Player.transform;
                Destroy(Bait.gameObject);
                Bait = null;
                state = State.Idle;
                break;            
        }
    }

    public void NextState(State expectedNextState)
    {
        state = state+1;
        if(state != expectedNextState)
        {
            Debug.LogWarning($"Not expected State! Expect {expectedNextState} but get {state}");
        }
    }
}