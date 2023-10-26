using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        SavePlayerPrefs.instance.OnApplicationPause(true);
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SavePlayerPrefs.instance.OnApplicationPause(false);

    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        //GameOver.isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
