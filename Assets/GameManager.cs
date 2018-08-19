using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public List<Item> Inventory;
	public int money;
	public InventorySlot[] invSlots;
	public List<Item> shelfItems;

	//Awake is always called before any Start functions
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);    
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
}
