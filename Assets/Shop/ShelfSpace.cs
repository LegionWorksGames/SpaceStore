using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfSpace : MonoBehaviour {

	Item item;
	Text title;
	Button btn;

	ShelfManager shelfMgr;

	// Use this for initialization
	void Start () {
		item = new Item ();
		title = GetComponentInChildren<Text> ();
		btn = GetComponent<Button> ();
		shelfMgr = FindObjectOfType<ShelfManager> ();
	}
	void Update() {
		title.text = item.itemName;
	}

	public void AddItem(Item newItem) {
		print ("adding " + newItem.itemName);
		item = newItem;
		title.text = item.itemName;
	}

	public void RemoveItem() {
		item = new Item ();
		title.text = item.itemName;
	}

	public Item GetItem() {
		return item;
	}

	public void SelectedShelf() {
		shelfMgr.ButtonSelect (btn);
		if (item.itemID >= 0) {
			shelfMgr.ShelfToInventory (item);
			RemoveItem ();
		}
	}

	public bool AvalibleSlot()
	{
		if (item.itemID == -1) {
			return true;
		} else {
			return false;
		}
	}
}
