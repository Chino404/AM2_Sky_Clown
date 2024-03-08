using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Player player;
    public GameObject gameOverCanvas;
    //public static bool isGameOver;

    void Update()
    {
        if (player != null)
        {
            if (player.life <= 0)
            {
                gameOverCanvas.SetActive(true);
                Time.timeScale = 0;

                //isGameOver = true;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        else
            Debug.LogWarning("FALTA EL PLAYER");
    }
}
