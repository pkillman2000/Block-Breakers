using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusTimer : MonoBehaviour
{
    [SerializeField]
    float timerLength;
    [SerializeField]
    private TextMeshProUGUI bonusTimerText;

    private bool timerStart = false;

    private float currentTimer;

    private void Start()
    {
        currentTimer = timerLength;
        bonusTimerText.text = Mathf.RoundToInt(currentTimer).ToString();
    }

    public void StartTimer()
    {
        timerStart = true;
    }

    private void Update()
    {
        if(timerStart == true)
        {
            CountDown();
            bonusTimerText.text = Mathf.RoundToInt(currentTimer).ToString();
        }
    }

    private void CountDown()
    {
        if (currentTimer <= 0)
        {
            currentTimer = 0;
        }
        else
        {
            currentTimer -= Time.deltaTime;
        }        
    }

    public int GetCurrentTimer()
    {
        return Mathf.RoundToInt(currentTimer);
    }
}
