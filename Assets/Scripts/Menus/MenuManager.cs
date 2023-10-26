using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static bool tutorialCompleted;
    public Button playButton;

    private void Start()
    {
        if (!tutorialCompleted)
        playButton.interactable=false;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void TutorialLevel()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;

        tutorialCompleted = true;

    }
    

}
