using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;


    private float m_Time;
    private bool m_IsWorking;

    void Start()
    {
        m_IsWorking = true;
        m_Time = 0.0F;
    }

    void Update()
    {
        int seconds;
        int minutes;

        if (m_IsWorking)
        {
            seconds = (int)m_Time % 60;
            minutes = (int)m_Time / 60;
            if (seconds <= 9)
            {
                timerText.text = (minutes + ":0" + seconds);
            }
            else
            {
                timerText.text = (minutes + ":" + seconds);
            }

            if (m_Time >= 0)
            {
                m_Time += Time.deltaTime;
            }
        }
    }

    /**
     * Hides the timer
     */
    public void Hide()
    {
        timerText.text = "";
        this.gameObject.SetActive(false);
    }

    /**
     * Returns the current time
     */
    public float GetCurrentTime()
    {
        return m_Time;
    }
}
