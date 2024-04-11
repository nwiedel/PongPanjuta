using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonController : MonoBehaviour
{
    public GameObject startPageUI;
    public GameObject playPageUI;
    public GameObject optionsPageUI;

    public void ShowStartPage()
    {
        startPageUI.SetActive(true);
        playPageUI.SetActive(false);
        optionsPageUI.SetActive(false);
    }
    public void ShowOptionsPage()
    {
        startPageUI.SetActive(false);
        playPageUI.SetActive(false);
        optionsPageUI.SetActive(true);
    }
    public void ShowPlayPage()
    {
        startPageUI.SetActive(false);
        playPageUI.SetActive(true);
        optionsPageUI.SetActive(false);
    }

    public void PlayGame()
    {
        Application.LoadLevel("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
