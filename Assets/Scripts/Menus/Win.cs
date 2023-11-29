using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winCanvas;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            Time.timeScale = 0;
            winCanvas.SetActive(true);

            CallJson.instance.save.GetSaveData.moneyJSON += 100;
            CallJson.instance.save.SaveJSON();

        }
    }
}
