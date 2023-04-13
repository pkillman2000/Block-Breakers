using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalBall : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] ballSounds;

    [SerializeField]
    private float randomFactor = 0.2f;

    private AudioSource myAudioSource;
    private Rigidbody2D myRigidBody2D;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = Random.Range(-randomFactor, randomFactor);
        float y = Random.Range(0, randomFactor);
        Vector2 velocityTweak = new Vector2(x, y);

        myRigidBody2D.velocity += velocityTweak;
        AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
        myAudioSource.PlayOneShot(clip);
    }
}
