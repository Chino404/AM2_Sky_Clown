using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{
    [SerializeField] private ItemButton _buttonPrefab = default;
    [SerializeField] private Transform _parent = default;

    [SerializeField] private Item[] items = new Item[0];

    void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            var newItem = Instantiate(_buttonPrefab, _parent);
            //newItem.transform.position = _parent.position;
            newItem.SetItem(items[i]);
        }
    }
}
