using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bait : MonoBehaviour
{
    [Header("Params")]
    public float maxVelocityX = 1f;
    public float maxVelocityY = -3f;
    public float towBackSpeed = 2f;
    
    [Range(0f, 1f)]
    public float controllSensityX = 0.1f;

    public float ropeLength = 50;

    
    // Variables
    [Header("Variables")]
    public Stack<Vector2> HistoryPos = new Stack<Vector2>();

    public float Depth => -transform.position.y;
    
    public float usedLength { get; private set; } = 0;
    public float RopeLeft => ropeLength - usedLength;
    public Fish FishCaught;


    Vector3 lastPos;
    Rigidbody2D rigidbody2D;
    Camera camera;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        camera = Camera.main;
        rigidbody2D = GetComponent<Rigidbody2D>();
        lastPos = transform.position;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(GameController.Instance.GameState == GameController.State.Fishing)
        {
            rigidbody2D.simulated = true;

            // input
            float mousePosX = Input.mousePosition.x;
            mousePosX -= Screen.width / 2;
            mousePosX /= (Screen.width / 2);
            if(mousePosX > 1) mousePosX = 1;
            if(mousePosX < -1) mousePosX = -1;
            // print(mousePosX);

            // calc pos
            Vector2 velocity = rigidbody2D.velocity;
            if(velocity.y < maxVelocityY)
            {
                velocity.y = maxVelocityY;
            }

            velocity.x = Mathf.Lerp(velocity.x, mousePosX * Mathf.Abs(maxVelocityX), controllSensityX);
            // print(velocity.y);

            rigidbody2D.velocity = velocity;

            //             
            if(usedLength >= ropeLength)
            {
                // length is exceed
                usedLength = ropeLength;
                GameController.Instance.NextState(GameController.State.TowBack);
            }
            else
            {
                // add length
                usedLength += (transform.position - lastPos).magnitude;
                lastPos = transform.position;   
                HistoryPos.Push(transform.position);
            }
        }
        else
        {
            rigidbody2D.simulated = false;
        }

        if(GameController.Instance.GameState == GameController.State.TowBack)
        {
            print(HistoryPos.Count);           

            float towDistanceLeft = towBackSpeed;
            while(towDistanceLeft > 0)
            {
                // stack sanity
                if(HistoryPos.Count == 0)
                {
                    GameController.Instance.NextState(GameController.State.Hook);
                    return;
                }

                // chaos towback code
                float tmpLeft = towDistanceLeft;
                towDistanceLeft -= Vector2.Distance((Vector2)transform.position, HistoryPos.Peek());
                Vector2 newPos = Vector2.MoveTowards(transform.position, HistoryPos.Peek(), tmpLeft);
                print($"{transform.position} -> {HistoryPos.Peek()} => {newPos} (Left {towDistanceLeft})");
                if(towDistanceLeft > 0)
                    HistoryPos.Pop();
                transform.position = newPos;
            }
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        Fish fish = other.GetComponent<Fish>();
        if(fish)
        {
            GameController.Instance.NextState(GameController.State.TowBack);
            FishCaught = fish;
            fish.Caught();
        }
    }
}