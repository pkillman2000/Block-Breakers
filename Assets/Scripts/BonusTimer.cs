using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusTimer : MonoBehaviour
{
    [SerializeField]
    float _timerLength;
    [SerializeField]
    private TextMeshProUGUI _bonusTimerText;

    private bool _timerStart = false;

    private float _currentTimer;

    private void Awake()
    {
        _currentTimer = _timerLength;
        _bonusTimerText.text = Mathf.RoundToInt(_currentTimer).ToString();
    }

    public void StartTimer()
    {
        _timerStart = true;
    }

    private void Update()
    {
        if(_timerStart == true)
        {
            CountDown();
            _bonusTimerText.text = Mathf.RoundToInt(_currentTimer).ToString();
        }
    }

    private void CountDown()
    {
        if (_currentTimer <= 0)
        {
            _currentTimer = 0;
        }
        else
        {
            _currentTimer -= Time.deltaTime;
        }        
    }

    public int GetCurrentTimer()
    {
        return Mathf.RoundToInt(_currentTimer);
    }
}
