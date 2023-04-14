using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    GameSession _gameSession;

    // Start is called before the first frame update
    void Start()
    {
        _gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
        if(_gameSession == null)
        {
            Debug.Log("Game Session is Null!");
        }

        _gameSession.HideScoreText();
        _scoreText.text = _gameSession.GetCurrentScore().ToString();
    }    
}
