using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f; // время в нормальном режиме
        PauseGame = false; // игра не на паузе
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f; // время заморожено
        PauseGame = true; // игра на паузе
    }

    public void LoadMenu() // метод для перехода в меню
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
