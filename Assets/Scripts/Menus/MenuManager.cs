using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //public bool tutorialCompleted;
    public Button playButton;

    public Canvas menuCanvas;
    public Canvas shopCanvas;

    private void Start()
    {
        print(CallJson.instance.save.GetSaveData.tutorialCompletedJSON);
        //print(CallJson.instance.save.GetSaveData.energy);
        print(CallJson.instance.save.GetSaveData.lifeJSON);

        StartCoroutine(LoadData());
        //LoadDataII();
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

        //tutorialCompleted = true;
        CallJson.instance.save.GetSaveData.tutorialCompletedJSON = true;
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

    private IEnumerator LoadData()
    {
        yield return new WaitForEndOfFrame();
        print(CallJson.instance.save.GetSaveData.tutorialCompletedJSON);
        playButton.interactable = CallJson.instance.save.GetSaveData.tutorialCompletedJSON;
    }
    private void LoadDataII()
    {
        print(CallJson.instance.save.GetSaveData.tutorialCompletedJSON);
        playButton.interactable = CallJson.instance.save.GetSaveData.tutorialCompletedJSON;
    }
}
