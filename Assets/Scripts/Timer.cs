using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    public float startTime = 10.0f;
    private float timeRemaining = 0.0f;

    public TextMeshProUGUI timeRemainingLabel;

    public void StartClock()
    {
        timeRemaining = startTime;
    }

    void Update()
    {
        if (GameManager.Instance.gameIsPlaying == false)
        {
            return;
        }

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0.0f)
        {
            GameManager.Instance.GameOver();
            timeRemaining = 0;
        }

        if (timeRemaining >= 0.0f)
        {
            var labelString = string.Format("{0:0}", timeRemaining);
            timeRemainingLabel.text = labelString;
        }

    }
}
