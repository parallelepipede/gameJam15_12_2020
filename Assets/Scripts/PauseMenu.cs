using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GUISkin guiskin;

    bool m_isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_isPaused = !m_isPaused;
        }

        if (m_isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    void OnGUI()
    {
        GUI.skin = guiskin;

        const int buttonWidth = 350;
        const int buttonHeight = 80;

        if (m_isPaused)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 80, buttonWidth, buttonHeight), "Resume"))
            {
                m_isPaused = false;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, buttonWidth, buttonHeight), "Restart"))
            {
                SceneManager.LoadScene(1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 160, buttonWidth, buttonHeight), "Quit"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
