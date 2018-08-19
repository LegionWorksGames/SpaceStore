using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvAdjust : MonoBehaviour {

	Text title;
	Item item;
	Inventory inventory;

	// Use this for initialization
	void Start () {
		title = transform.Find ("Title").GetComponentInChildren<Text> ();
		item = new Item ();
		inventory = FindObjectOfType<Inventory> ();
	}

	public void SetItem(Item newItem)
	{
		item = newItem;
		title.text = item.itemName;
	}

	public void AddToItem()
	{
		if (GameManager.instance.money >= item.itemValue) {
			inventory.AddItemToInventory (item);
			GameManager.instance.money -= Mathf.RoundToInt(item.itemValue * 1.05f);
		}
	}

	public void RemoveFromItems()
	{
		if (inventory.ItemIsInInventory(item)) {
			inventory.RemoveFromItems (item);
			GameManager.instance.money += item.itemValue;
		}
	}
}
