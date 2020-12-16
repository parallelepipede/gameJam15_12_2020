using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GUISkin guiskin;

    void OnGUI()
    {
        GUI.skin = guiskin;

        const int buttonWidth = 200;
        const int buttonHeight = 80;

        /*const int labelWidth = 300;
        const int labelHeight = 90;*/

        if (GUI.Button(
            new Rect(
                Screen.width / 2 - (buttonWidth / 2),
                (2 * Screen.height / 3) - (buttonHeight / 2),
                buttonWidth,
                buttonHeight), "Play"))
        {
            SceneManager.LoadScene(1);
        }

        if (GUI.Button(
            new Rect(
                Screen.width / 2 - (buttonWidth / 2),
                (Screen.height) - (2 * buttonHeight),
                buttonWidth,
                buttonHeight), "Exit"))
        {
            Application.Quit();
        }

        /*int score = PlayerPrefs.GetInt("bestscore");

        GUI.Label(new Rect(Screen.width / 2 - labelWidth,
                (2 * Screen.height / 3) - (buttonHeight / 2) - labelHeight, labelWidth, labelHeight), "Best score : " + score);*/

    }
}

