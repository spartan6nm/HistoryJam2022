using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInTheScene : MonoBehaviour
{
    public Item item;

    public Image image;


    private void Start()
    {
        if (Inventory.instance.items.Contains(item))
        {
            Destroy(this.gameObject);
        }
        image.sprite = item.itemSprite;
    }
    public void Clicked()
    {
        Inventory.instance.Add(item);

        Destroy(this.gameObject);
    }
}
