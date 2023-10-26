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
        if(player.life<=0)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;

            //isGameOver = true;
        }
        //if (isGameOver)
        //    Time.timeScale = 0;
    }
}
