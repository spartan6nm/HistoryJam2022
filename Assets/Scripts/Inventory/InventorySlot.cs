using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour {

	public Image icon;

	Item item;	// Current item in the slot

	// Add item to the slot
	public void AddItem (Item newItem)
	{
		item = newItem;

		icon.sprite = item.itemSprite;
		icon.enabled = true;
	}

	// Clear the slot
	public void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
	}

	// If the remove button is pressed, this function will be called.
	public void RemoveItemFromInventory ()
	{
		Inventory.instance.Remove(item);
	}

	/*
	// Use the item
	public void UseItem ()
	{
		if (item != null)
		{
			item.Use();
		}
	}
	*/
}
