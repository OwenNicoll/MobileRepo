using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// PURPOSE: This script will allow the menu buttons to function

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the first level if player presses the play button
        SceneManager.LoadScene("Level01");
    }

    public void QuitGame()
    {
        // Quit the program if player presses the quit button
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
