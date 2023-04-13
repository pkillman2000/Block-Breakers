using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float screenXUnits = 16f;
    [SerializeField]
    private float minimumX = 0.5f;
    [SerializeField]
    private float maximumX = 15.5f;

    private GameSession autoPlay;
    private Ball theBall;
    private void Awake()
    {
    // FindObjectOfType is expensive.  We create a reference here
    // so that we only call it once.
        autoPlay = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        float paddleXPosition;

        if (autoPlay.IsAutoPlayEnabled())
        {
            paddleXPosition = theBall.transform.position.x;
        }
        else
        {
            // Get mouse cursor X position and convert to local view
            // Limit X position to keep paddle on screen
            paddleXPosition = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenXUnits, minimumX, maximumX);
        }

        // Get paddle Y position
        float paddleYPosition = gameObject.transform.position.y;
        
        // Create new paddle position
        Vector2 paddlePosition = new Vector2(paddleXPosition, paddleYPosition);
        // Move paddle
        gameObject.transform.position = paddlePosition;
    }
}
