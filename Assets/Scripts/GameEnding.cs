using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField]
    private CanvasGroup caughtBackgroundImageCanvasGroup;

    [SerializeField]
    private Timer timer;
    [SerializeField]
    private GUISkin guiskin;

    private float fadeDuration = 0.5f;
    private float displayImageDuration = 0.5f;

    private int m_Score;
    private float m_Time;
    private bool m_IsPlayerAtExit;
    private bool m_IsPlayerDead = false;
    private float m_Timer;
    private bool m_HasAudioPlayed;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void DeadPlayer()
    {
        m_IsPlayerDead = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup);
        }
        else if (m_IsPlayerDead)
        {
            EndLevel(caughtBackgroundImageCanvasGroup);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        //hiding the labels
        timer.Hide();

        if (m_IsPlayerAtExit)
        {
            //calcul of the score only if the player has won
            m_Time = timer.GetCurrentTime();

            m_Score = (int)(120000 / m_Time);

            if (m_Score > PlayerPrefs.GetInt("bestscore"))
            {
                PlayerPrefs.SetInt("bestscore", m_Score);
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = guiskin;

        if (m_IsPlayerAtExit || m_IsPlayerDead)
        {
            const int buttonWidth = 500;
            const int buttonHeight = 80;

            if (GUI.Button(
                new Rect(
                    250,
                    50,
                    buttonWidth,
                    buttonHeight), "Main menu"))
            {
                SceneManager.LoadScene(0);
            }

            if (GUI.Button(
                new Rect(
                    250,
                    160,
                    buttonWidth,
                    buttonHeight), "Play again"))
            {
                SceneManager.LoadScene(1);
            }
        }

        if (m_IsPlayerAtExit)
        {
            const int labelWidth = 800;
            const int labelHeight = 150;

            GUI.Label(new Rect(225, 270, labelWidth, labelHeight), "Final score : " + m_Score.ToString());
        }
    }
}
