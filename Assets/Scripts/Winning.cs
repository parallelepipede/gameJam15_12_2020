using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Winning : MonoBehaviour
{

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }
    }
}
