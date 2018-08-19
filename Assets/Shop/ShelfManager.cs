using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfManager : MonoBehaviour {

	Button selectedButton;
	Inventory inv;

	// Use this for initialization
	void Start () {
		inv = GetComponent<Inventory> ();
	}
	
	public void ButtonSelect(Button btn) {
		// ShelfSpace.SelectedShelf
		selectedButton = btn;
	}

	public void ShelfNewItem(Item item) {
		if(selectedButton != null)
		{
			ShelfSpace shelf = selectedButton.GetComponent<ShelfSpace> ();
			if (shelf.AvalibleSlot ()) {
				shelf.AddItem (item);
				inv.RemoveFromItems (item);
			}
		}
	}

	public void ShelfToInventory(Item item) {
		inv.AddItemToInventory (item);
	}

}
