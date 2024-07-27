using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    public void TutorialLevel()
    {
        SceneManager.LoadSceneAsync(4);

        CallJson.instance.save.GetSaveData.tutorialCompletedJSON = true;
        CallJson.instance.save.SaveJSON();
    }
}
