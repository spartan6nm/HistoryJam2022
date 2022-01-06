using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Interactable/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    [TextArea(1,5)]
    public string itemDecription;

    public Sprite itemSprite;

    public bool showInInventory = true;

}
