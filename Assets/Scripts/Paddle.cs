using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float _screenXUnits;
    [SerializeField]
    private float _minimumX;
    [SerializeField]
    private float _maximumX;

    private GameSession _gameSession;
    private Ball _ball;

    private void Awake()
    {
    // FindObjectOfType is expensive.  We create a reference here
    // so that we only call it once.
        _gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
        if(_gameSession == null)
        {
            Debug.Log("Auto Play is Null!");
        }

        _ball = GameObject.Find("Ball").GetComponent<Ball>();
        if(_ball == null)
        {
            Debug.Log("The Ball is Null!");
        }
    }

    private void Update()
    {
        float paddleXPosition;

        if (_gameSession.IsAutoPlayEnabled())
        {
            paddleXPosition = _ball.transform.position.x;
        }
        else
        {
            // Get mouse cursor X position and convert to local view
            // Limit X position to keep paddle on screen
            paddleXPosition = Mathf.Clamp(Input.mousePosition.x / Screen.width * _screenXUnits, _minimumX, _maximumX);
        }

        // Get paddle Y position
        float paddleYPosition = gameObject.transform.position.y;
        
        // Create new paddle position
        Vector2 paddlePosition = new Vector2(paddleXPosition, paddleYPosition);
        // Move paddle
        gameObject.transform.position = paddlePosition;
    }
}
