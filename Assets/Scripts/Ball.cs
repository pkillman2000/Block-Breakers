using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{    
    [SerializeField]
    private Paddle paddle1;
    [SerializeField]
    private Vector2 launchVelocity;
    [SerializeField]
    private AudioClip[] ballSounds;
    [SerializeField]
    private AudioClip launchBallSFX;
    [SerializeField]
    private float randomFactor = 0.2f;

    private Vector2 paddleToBallOffset;
    private bool hasStarted = false;
    private AudioSource myAudioSource;
    private Rigidbody2D myRigidBody2D;
    private BonusTimer bonusTimer;
    private GameSession gameSession;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        bonusTimer = FindObjectOfType<BonusTimer>();
        gameSession = FindObjectOfType<GameSession>();

        paddleToBallOffset = gameObject.transform.position - paddle1.transform.position;
    }

    private void LateUpdate()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        gameObject.transform.position = paddlePos + paddleToBallOffset;
    }

    private void LaunchBallOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myAudioSource.PlayOneShot(launchBallSFX);
            myRigidBody2D.velocity = launchVelocity;
            bonusTimer.StartTimer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = Random.Range(-randomFactor, randomFactor);
        float y = Random.Range(0, randomFactor);
        Vector2 velocityTweak = new Vector2(x, y);

        if (hasStarted)
        {
            myRigidBody2D.velocity += velocityTweak;
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
