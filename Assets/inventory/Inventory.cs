using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	Text moneyTxt;

	// Use this for initialization
	void Start () {
		GameManager.instance.invSlots = GetComponentsInChildren<InventorySlot> ();
		moneyTxt = transform.Find ("Money").GetComponent<Text>();
		SetupInventory (ItemsInInventory());
		GameManager.instance.money = 500;
	}

	void Update()
	{
		moneyTxt.text = GameManager.instance.money.ToString ();
	}
	
	public void SetupInventory(List<Item> items)
	{
		for (int i = 0; i < GameManager.instance.invSlots.Length; i++) {
			if (i < items.Count) {
				GameManager.instance.invSlots [i].AddItem (items [i]);
			} else {
				GameManager.instance.invSlots [i].ClearItem ();
			}
		}
	}

	public void AddItemToInventory(Item item)
	{
		int takenSlots = 0;
		foreach (InventorySlot inv in GameManager.instance.invSlots) {
			if (inv.ThisIsTheItem (item)) {
				inv.UpdateItem ();
				return;
			}
			if (!inv.AvalibleSlot ()) {
				takenSlots++;
			}
		}
		foreach (InventorySlot inv in GameManager.instance.invSlots) {
			if (inv.AvalibleSlot ()) {
				inv.AddItem (item);
				inv.SetChildIndex (takenSlots);
				return;
			}
		}
	}

	public void RemoveFromItems(Item item)
	{
		foreach (InventorySlot inv in GameManager.instance.invSlots) {
			if(inv.ThisIsTheItem(item))
			{
				inv.RemoveItem();
				if (inv.AvalibleSlot()) {
					inv.SetChildIndex(GameManager.instance.invSlots.Length);
				}
				break;
			}
		}
	}
	public bool ItemIsInInventory(Item item)
	{
		foreach (InventorySlot inv in GameManager.instance.invSlots) {
			if (inv.ThisIsTheItem (item)) {
				return true;
			}
		}
		return false;
	}

	public List<Item> ItemsInInventory()
	{
		List<Item> newItems = new List<Item>();
		foreach (InventorySlot inv in GameManager.instance.invSlots) {
			if (!inv.AvalibleSlot()) {
				newItems.Add (inv.GetItem ());
			}
		}
		return newItems;
	}
}
