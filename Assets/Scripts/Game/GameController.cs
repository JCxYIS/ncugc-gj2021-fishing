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
    public FishSpawner FishSpawner;
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
        FishSpawner.Respawn();        
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
            case State.Hooking:
                if(Bait)
                {
                    virtualCamera.Follow = Player.transform;
                    if(Bait.FishCaught)
                    {
                        GameManager.Money += Bait.FishCaught.fishData.Score;
                        if(Bait.FishCaught.name == "RickRoll")
                            Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                    }
                    Destroy(Bait.gameObject);
                    Bait = null;
                }
                break;
            case State.End:
                FishSpawner.Respawn();
                state = State.Idle;
                break;
        }
    }

    public void NextState(State expectedNextState)
    {
        state = state+1;
        if(state != expectedNextState)
        {
            Debug.LogWarning($"Not expected State! Expect {expectedNextState} but get {state}. Force set to the later.");
            state = expectedNextState;
        }
    }
}