using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverDetection : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject boosts;
    public Button restartButton;
    
    private void Update()
    {
        // checks if player is dead
        if (GameObject.FindWithTag("Player"))
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
            boosts.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
