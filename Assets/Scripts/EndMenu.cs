using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.HideScoreText();
        scoreText.text = gameSession.GetCurrentScore().ToString();
    }    
}
