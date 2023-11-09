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

    public void SetItem(Item myItem)
    {
        _itemName.text = myItem.itemName;
        _itemCost.text = myItem.itemCost;
        _itemImage.sprite = myItem.itemImage;
    }
}
