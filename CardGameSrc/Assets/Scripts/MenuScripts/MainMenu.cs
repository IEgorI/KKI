using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // metod for button start
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // metod for button exit
    public void ExitGame()
    {
        Debug.Log("The game is closed");
        Application.Quit();
    }

}

