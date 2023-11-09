using UnityEngine;

[CreateAssetMenu(fileName = "My New Item", menuName = "CustomScriptableObject/Item")]
public class Item : ScriptableObject
{
    public string itemName = default, itemCost = default;
    public Sprite itemImage = default;
    public ItemRarity itemRarity = default;
}
