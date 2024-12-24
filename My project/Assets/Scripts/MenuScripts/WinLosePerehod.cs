using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLosePerehod : MonoBehaviour
{
    public void LoadMenu() // метод для перехода в меню
    {
        SceneManager.LoadScene("Menu");
    }
}
