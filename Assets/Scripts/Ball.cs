using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Ball : MonoBehaviour
{    
    [SerializeField]
    private Paddle _paddle1;
    [SerializeField]
    private Vector2 _launchVelocity;
    [SerializeField]
    private AudioClip[] _ballSounds;
    [SerializeField]
    private AudioClip _launchBallSFX;
    [SerializeField]
    private float _randomFactor = 0.2f;

    private Vector2 _paddleToBallOffset;
    private bool _hasStarted = false;

    private AudioSource _audioSource;
    private Rigidbody2D _rigidBody2D;
    private BonusTimer _bonusTimer;
    private GameSession _gameSession;
    private AudioClip _audioClip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.Log("My Audio Source is Null!");
        }
        
        _rigidBody2D = GetComponent<Rigidbody2D>();
        if(_rigidBody2D == null)
        {
            Debug.Log("My RIgid Body is Null!");
        }
        
        _bonusTimer = GameObject.Find("Bonus Timer").GetComponent<BonusTimer>();
        if(_bonusTimer == null)
        {
            Debug.Log("Bonus Timer is Null!");
        }
        
        _gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
        if(_gameSession == null) 
        {
            Debug.Log("Game Session is Null!");
        }

        _paddleToBallOffset = gameObject.transform.position - _paddle1.transform.position;
    }

    private void LateUpdate()
    {
        if(!_hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(_paddle1.transform.position.x, _paddle1.transform.position.y);
        gameObject.transform.position = paddlePos + _paddleToBallOffset;
    }

    private void LaunchBallOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _hasStarted = true;
            _audioSource.PlayOneShot(_launchBallSFX);
            _rigidBody2D.velocity = _launchVelocity;
            _bonusTimer.StartTimer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = Random.Range(-_randomFactor, _randomFactor);
        float y = Random.Range(0, _randomFactor);
        Vector2 velocityTweak = new Vector2(x, y);

        if (_hasStarted)
        {
            _rigidBody2D.velocity += velocityTweak;
            _audioClip = _ballSounds[Random.Range(0, _ballSounds.Length)];
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
