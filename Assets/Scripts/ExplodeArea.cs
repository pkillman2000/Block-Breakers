﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeArea : MonoBehaviour
{
    [SerializeField]
    private AudioClip _breakSound;
    [SerializeField]
    private GameObject _blockSparklesVFX;

    Level _level;
    GameSession _gameSession;

    private void Start()
    {
        _gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
        if(_gameSession == null)
        {
            Debug.Log("Game Session is Null!");
        }
        _level = GameObject.Find("Level").GetComponent<Level>();
        if(_level == null)
        {
            Debug.Log("Level is Null!");
        }

        _level.CountBlocks();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SelectionRect();        
    }

    private void SelectionRect()
    {
        Vector2 point1 = new Vector2(transform.position.x - 1, transform.position.y + 1);
        Vector2 point2 = new Vector2(transform.position.x + 1, transform.position.y - 1);
        Collider2D[] hit = Physics2D.OverlapAreaAll(point1, point2);
        foreach(Collider2D collider2D in hit)
        {
            if(collider2D.tag == "Breakable")
            {
                Vector2 blockLocation = new Vector2(collider2D.transform.position.x, collider2D.transform.position.y);
                int points = collider2D.GetComponent<Block>().GetHitSprites();
                DestroyBlock(blockLocation);
                Destroy(collider2D.gameObject);
                _gameSession.AddToScore(points);
            }
        }
        
        _level.BlockDestroyed();
        Destroy(this.gameObject);
    }

    private void DestroyBlock(Vector2 blockLocation)
    {
        GameObject sparkles = Instantiate(_blockSparklesVFX, blockLocation, Quaternion.identity);
        Destroy(sparkles, .5f);
        AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);
        _level.BlockDestroyed();
        _gameSession.AddToScore(1);
    }

}
