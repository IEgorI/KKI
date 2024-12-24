using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text login;
    public Text coins;
    // metod for button start
    public void Update()
    {
        login.text = "Логин: " + GlobalData.userlogin;
        coins.text = "Монеты: " + GlobalData.coins.ToString();
    }
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

