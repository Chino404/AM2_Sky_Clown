using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public static LifeCounter instance;

    public Text lifeText;
    int _lifeNumber;
    public Player lifePlayer;

    void Update()
    {
        ChangeNumberLifeTXT();
    }

    public void ChangeNumberLifeTXT()
    {
        _lifeNumber = lifePlayer.life;
        lifeText.text = _lifeNumber.ToString();
    }
}
