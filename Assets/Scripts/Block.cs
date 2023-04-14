using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private AudioClip _breakSound;
    [SerializeField]
    private GameObject _blockSparklesVFX;
    private int _timesHit;
    [SerializeField]
    private Sprite[] _hitSprites;
    [SerializeField]
    private int _pointsPerHitSprites;

    Level _level;
    GameSession _gameSession;

    private void Start()
    {
        _gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
        if(_gameSession == null)
        {
            Debug.Log("Game Session is Null");
        }

        _level = GameObject.Find("Level").GetComponent<Level>();        
        if(_level == null)
        {
            Debug.Log("Level is Null");
        }

        CountBreakableBlocks();
    }

    public int GetHitSprites()
    {
        return _hitSprites.Length + 1;
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            _level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        _timesHit++;
        int maxHits = _hitSprites.Length + 1;
        if (_timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = _timesHit - 1;
        if(_hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = _hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {        
        TriggerSparklesVFX();
        AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);        
        _gameSession.AddToScore(_hitSprites.Length + 1);        
        _level.BlockDestroyed();
        Destroy(this.gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(_blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, .5f);
    }
}
