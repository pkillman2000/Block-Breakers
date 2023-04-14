using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int _breakableBlocks;
    private SceneLoader _sceneLoader;
    private BonusTimer _bonusTimer;
    private GameSession _gameSession;

    private void Start()
    {
        _sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        if(_sceneLoader == null)
        {
            Debug.Log("Scene Loader is Null!");
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
    }

    public void CountBlocks()
    {
        _breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        _breakableBlocks--;

        if (_breakableBlocks == 0)
        {
            int bonus = _bonusTimer.GetCurrentTimer();
            _gameSession.AddBonus(bonus);
            _sceneLoader.LoadNextScene();
        }
    }
}
