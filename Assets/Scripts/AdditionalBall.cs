using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalBall : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _ballSounds;

    [SerializeField]
    private float _randomFactor = 0.2f;

    private AudioSource _audioSource;
    private Rigidbody2D _ribigBody2D;
    private AudioClip _audioClip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if(_audioSource == null)
        {
            Debug.Log("My Audio Source is Null!");
        }
        
        _ribigBody2D = GetComponent<Rigidbody2D>();
        if(_ribigBody2D == null)
        {
            Debug.Log("My Rigid Body 2D is Null!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = Random.Range(-_randomFactor, _randomFactor);
        float y = Random.Range(0, _randomFactor);
        Vector2 velocityTweak = new Vector2(x, y);

        _ribigBody2D.velocity += velocityTweak;
        _audioClip = _ballSounds[Random.Range(0, _ballSounds.Length)];
        _audioSource.PlayOneShot(_audioClip);
    }
}
