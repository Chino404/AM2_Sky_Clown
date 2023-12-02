using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winCanvas;

    public TextMeshProUGUI textMoney;
    public int numberMoney;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            Time.timeScale = 0;
            winCanvas.SetActive(true);

            if(textMoney != null)
            {
                CallJson.instance.save.GetSaveData.moneyJSON += numberMoney;
                textMoney.text = "+" + numberMoney;
            }
            CallJson.instance.save.SaveJSON();

        }
    }
}
