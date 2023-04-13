using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private AudioClip breakSound;
    [SerializeField]
    private GameObject blockSparklesVFX;
    [SerializeField]
    private int timesHit;
    [SerializeField]
    private Sprite[] hitSprites;
    [SerializeField]
    private int pointsPerHitSprites;

    Level level;
    GameSession gameStatus;

    private void Start()
    {
        CountBreakableBlocks();

        gameStatus = FindObjectOfType<GameSession>();
    }

    public int GetHitSprites()
    {
        return hitSprites.Length + 1;
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.CountBlocks();
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
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
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
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {        
        TriggerSparklesVFX();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);        
        gameStatus.AddToScore(hitSprites.Length + 1);        
        level.BlockDestroyed();
        Destroy(this.gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, .5f);
    }
}
