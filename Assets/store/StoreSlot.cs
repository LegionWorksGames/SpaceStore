using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour {

	Text title, text, value;
	Item item;
	int m_IndexNumber;

	// Use this for initialization
	void Start () {
		title = transform.Find ("Title").GetComponent<Text> ();
		text = transform.Find ("Text").GetComponent<Text> ();
		value = transform.Find ("Value").GetComponent<Text> ();
		item = new Item ();
		m_IndexNumber = transform.GetSiblingIndex ();
	}

	public void SetCurrentItem()
	{
		FindObjectOfType<InvAdjust> ().SetItem (item);
	}

	public void AddItem(Item newItem)
	{
		item = newItem;
		title.text = item.itemName;
		text.text = item.itemDesc;
		value.text = Mathf.RoundToInt(item.itemValue * 1.05f).ToString ();
	}

	public void ClearItem()
	{
		item = new Item ();
		title.text = "";
		text.text = "";
		value.text = "";
	}
}
