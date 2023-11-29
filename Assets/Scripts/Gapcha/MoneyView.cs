using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    public static MoneyView Instance;

    public TextMeshProUGUI textCost; //Para ver los costos
    public int money;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //money = CallJson.instance.save.GetSaveData.moneyJSON;
        //textCost.text = "MONEY: " + money;
    }

    private void Update()
    {
        money = CallJson.instance.save.GetSaveData.moneyJSON;
        textCost.text = "" + money;
    }

    public void SubstracMoney(int cost)
    {
        money -= cost;
        CallJson.instance.save.GetSaveData.moneyJSON = money;
        CallJson.instance.save.SaveJSON();
    }

    public void SetCost(int vnewCost)
    {
        money += vnewCost;
        money = Mathf.Clamp(money, 0, 99);
        //textCost.text = "Money: " + cost;
    }
}
