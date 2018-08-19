using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour {

	[SerializeField] TextAsset jsonFile;
	public static List<Item> items;

	void Start()
	{
		items = ParseJsonToItems(jsonFile);
	}

	public List<Item> ParseJsonToItems(TextAsset json)
	{
		var wrappedjsonArray = JsonUtility.FromJson<Items>(json.text);
		return wrappedjsonArray.items;
	}
}
	
[System.Serializable]
public class Items {

	public List<Item> items;
}

[System.Serializable]
public class Item {

	public int itemID;
	public string itemName;
	public string itemDesc;
	public int itemValue;
	public bool itemUseable;

	public Item()
	{
		itemID = -1;
	}
	public Item(int id, string name, string desc, int value, bool useable)
	{
		itemID = id;
		itemName = name;
		itemDesc = desc;
		itemValue = value;
		itemUseable = useable;
	}
}