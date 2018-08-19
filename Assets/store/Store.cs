using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {

	public StoreSlot[] invSlots;

	// Use this for initialization
	void Start () {
		invSlots = GetComponentsInChildren<StoreSlot> ();
		SetupInventory (ItemsManager.items);
	}

	public void SetupInventory(List<Item> items)
	{
		for (int i = 0; i < invSlots.Length; i++) {
			if (i < items.Count) {
				invSlots [i].AddItem (items [i]);
			} else {
				invSlots [i].ClearItem ();
			}
		}
	}
}
