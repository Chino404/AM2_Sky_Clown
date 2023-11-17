using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static bool tutorialCompleted;
    public Button playButton;

    public Canvas menuCanvas;
    public Canvas shopCanvas;

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
        CallJson.instance.save.GetSaveData.tutorialCompleted = true;
        CallJson.instance.save.SaveJSON();

    }

    public void Shop()
    {
        menuCanvas.gameObject.SetActive(false);
        shopCanvas.gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        menuCanvas.gameObject.SetActive(true);
        shopCanvas.gameObject.SetActive(false);
    }

}
