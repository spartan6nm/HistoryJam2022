using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	#region Singleton

	public static Inventory instance;

	void Awake()
	{
		instance = this;
	}

	#endregion


	public int space = 10;  // Amount of item spaces

	// Our current list of items in the inventory
	public List<Item> items = new List<Item>();

	// Add a new item if enough room
	public void Add(Item item)
	{
		if (item.showInInventory)
		{
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return;
			}

			items.Add(item);

			EventBroker.CallItemChanged();
		}
	}

	// Remove an item
	public void Remove(Item item)
	{
		items.Remove(item);

		EventBroker.CallItemChanged();
	}

}
