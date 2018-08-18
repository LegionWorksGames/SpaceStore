using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager : MonoBehaviour {

	[SerializeField] TextAsset jsonFile;
	public static List<Research> research;

	void Start()
	{
		research = ParseJsonToItems(jsonFile);
	}

	public List<Research> ParseJsonToItems(TextAsset json)
	{
		var wrappedjsonArray = JsonUtility.FromJson<Reaseachable>(json.text);
		return wrappedjsonArray.researchable;
	}
}

[System.Serializable]
public class Reaseachable {

	public List<Research> researchable;
}

[System.Serializable]
public class Research {

	public int researchID;
	public string researchName;
	public string researchDesc;
	public int researchTime;
	public bool researchComplete;
}