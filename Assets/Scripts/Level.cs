using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int breakableBlocks;
    private SceneLoader sceneLoader;
    private BonusTimer bonusTimer;
    private GameSession gameSession;

    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        bonusTimer = FindObjectOfType<BonusTimer>();
        gameSession = FindObjectOfType<GameSession>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;

        if (breakableBlocks == 0)
        {
            int bonus = bonusTimer.GetCurrentTimer();
            gameSession.AddBonus(bonus);
            sceneLoader.LoadNextScene();
        }
    }
}
