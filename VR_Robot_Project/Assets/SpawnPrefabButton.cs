using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPrefabButton : MonoBehaviour {

	public string folderName = "3DPrefabs";
	public GameObject[] faces;
	int index = 0;

	// Use this for initialization
	void Start () {
		string filepath = "RobotParts/" + folderName + "/";
		faces = Resources.LoadAll<GameObject> (filepath);
		Change (0);
	}

	public void Change(int n) {
		index += n;
		if (index >= faces.Length) {
			index = 0;
		} else if (index < 0) {
			index = faces.Length - 1;
		}
		if (faces.Length > 0) {
			transform.GetChild (0).gameObject.GetComponentInChildren<Text>().text = "Proto-Model " + (index+1);
		}
	}

	public void Spawn() {
		GameObject g = Instantiate (faces [index], GameObject.FindObjectOfType<PartCreator> ().transform.position, Quaternion.identity);
		g.transform.localScale *= 0.35f;
	}
}
