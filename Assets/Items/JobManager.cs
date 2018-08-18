using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour {

	[SerializeField] TextAsset jsonFile;
	public static List<Job> jobs;

	void Start()
	{
		jobs = ParseJsonToItems(jsonFile);
	}

	public List<Job> ParseJsonToItems(TextAsset json)
	{
		var wrappedjsonArray = JsonUtility.FromJson<Jobs>(json.text);
		return wrappedjsonArray.jobs;
	}
}

[System.Serializable]
public class Jobs {

	public List<Job> jobs;
}

[System.Serializable]
public class Job {

	public int jobID;
	public string jobName;
	public string jobDesc;
}