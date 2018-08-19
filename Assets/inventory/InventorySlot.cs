using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	Text title, text, quantity, value;
	Item item;
	int numOfItems = 0;
	int m_IndexNumber;

	// Use this for initialization
	void Start () {
		title = transform.Find ("Title").GetComponent<Text> ();
		text = transform.Find ("Text").GetComponent<Text> ();
		quantity = transform.Find ("Quantity").GetComponent<Text> ();
		value = transform.Find ("Value").GetComponent<Text> ();
		item = new Item ();
		m_IndexNumber = transform.GetSiblingIndex ();
	}

	public void AddItem(Item newItem)
	{
		numOfItems = 1;
		item = newItem;
		title.text = item.itemName;
		text.text = item.itemDesc;
		value.text = item.itemValue.ToString ();

		quantity.text = numOfItems.ToString();
	}

	public void UpdateItem()
	{
		if (numOfItems > 0) {
			numOfItems++;
			quantity.text = numOfItems.ToString ();
		}
	}

	public void RemoveItem()
	{
		if (numOfItems > 1) {
			numOfItems--;
			quantity.text = numOfItems.ToString();
		} else {
			ClearItem ();
		}
	}

	public void ClearItem()
	{
		item = new Item ();
		title.text = "";
		text.text = "";
		quantity.text = "";
		value.text = "";
	}

	public bool AvalibleSlot()
	{
		if (item.itemID == -1) {
			return true;
		} else {
			return false;
		}
	}

	public bool ThisIsTheItem(Item newItem)
	{
		if (item.itemID == newItem.itemID) {
			return true;
		} else {
			return false;
		}
	}

	// REQUIRES STORE
	public void SetCurrentItem()
	{
		FindObjectOfType<InvAdjust> ().SetItem (item);
	}
	// -------------

	// REQUIRES SHELVES
	public void ShelfNewItem()
	{
		print ("passing " + item.itemName);
		FindObjectOfType<ShelfManager> ().ShelfNewItem (item);
	}
	// --------------

	public void SetChildIndex(int index)
	{
		m_IndexNumber = index;
		transform.SetSiblingIndex (m_IndexNumber);
	}

	public Item GetItem()
	{
		return item;
	}
}
