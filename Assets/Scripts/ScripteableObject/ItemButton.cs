using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemCost;
    [SerializeField] private Image _itemImage;

    public  int cost;

    private void Start()
    {
    }

    public void SetItem(Item myItem)
    {
        _itemName.text = myItem.itemName;
        _itemCost.text = myItem.itemCost;
        cost = int.Parse(myItem.itemCost);
        _itemImage.sprite = myItem.itemImage;
    }

    public void BuyItem()
    {
        var money = CallJson.instance.save.GetSaveData.moneyJSON;

        if(money >= cost)
        {
            MoneyView.Instance.SubstracMoney(cost);
        }
    }
}
