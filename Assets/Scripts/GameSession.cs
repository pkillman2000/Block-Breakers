using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField]
    private float gameSpeed = 1f;    
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private bool isAutoPlayEnabled;
    [SerializeField]
    float timerLength = 1000f;

    private int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            // Object is not destroyed until the end of the cycle, so there can
            // be two instances of this object for a brief amount of time.
            // Turning it inactive will stop this instance from doing anything
            // until it is destroyed.
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void LateUpdate()
    {
        Time.timeScale = gameSpeed;        
    }

    public void AddToScore(int pointsToAdd)
    {
        currentScore += pointsToAdd;
        scoreText.text = currentScore.ToString();
    }

    public void AddBonus(int bonusToAdd)
    {
        currentScore += bonusToAdd;
        scoreText.text = currentScore.ToString();
    }

    public void HideScoreText()
    {
        scoreText.text = "";
    }

    public void ResetGame()
    {
        Debug.Log("Reset Game");
        Destroy(this.gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
