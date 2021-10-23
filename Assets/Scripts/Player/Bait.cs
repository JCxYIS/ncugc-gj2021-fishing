using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bait : MonoBehaviour
{
    [Header("Params")]
    public float maxVelocityX = 1f;
    public float maxVelocityY = -3f;
    
    [Range(0f, 1f)]
    public float controllSensityX = 0.1f;

    public float ropeLength = 50;

    
    // Variables
    public float Depth => -transform.position.y;

    public float usedLength { get; private set; } = 0;
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
        }
        else
        {
            rigidbody2D.simulated = false;
        }

        // 
        usedLength += (transform.position - lastPos).magnitude;
        lastPos = transform.position;
    }

    void CalcPos()
    {
        
    }
}