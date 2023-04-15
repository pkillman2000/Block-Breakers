using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField]
    private float _gameSpeed = 1f;    
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private bool _isAutoPlayEnabled;

    private int _currentScore = 0;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _isAutoPlayEnabled = !_isAutoPlayEnabled;
        }
    }
    private void LateUpdate()
    {
        Time.timeScale = _gameSpeed;        
    }

    public void AddToScore(int pointsToAdd)
    {
        _currentScore += pointsToAdd;
        _scoreText.text = _currentScore.ToString();
    }

    public void AddBonus(int bonusToAdd)
    {
        _currentScore += bonusToAdd;
        _scoreText.text = _currentScore.ToString();
    }

    public void HideScoreText()
    {
        _scoreText.text = "";
    }

    public void ResetGame()
    {
        Destroy(this.gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return _isAutoPlayEnabled;
    }

    public int GetCurrentScore()
    {
        return _currentScore;
    }
}
