using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour {

	[SerializeField] TextAsset jsonFile;
	public static List<Member> crewMembers;

	void Start()
	{
		crewMembers = ParseJsonToItems(jsonFile);
	}

	public List<Member> ParseJsonToItems(TextAsset json)
	{
		var wrappedjsonArray = JsonUtility.FromJson<Crew>(json.text);
		return wrappedjsonArray.member;
	}
}

[System.Serializable]
public class Crew {

	public List<Member> member;
}

[System.Serializable]
public class Member {

	public int crewID;
	public string crewName;
	public string crewDesc;
	public int crewJob;
	public bool crewSkill;
}