using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartTemplateBehavior : MonoBehaviour {

	public string folderName = "Arms";
	public Sprite[] faces;
	int index = 0;

	// Use this for initialization
	void Start () {
		string filepath = "RobotParts/" + folderName + "/";
		faces = Resources.LoadAll<Sprite> (filepath);
		Change (0);
	}

	public void Change(int n) {
		index += n;
		if (index >= faces.Length) {
			index = 0;
		} else if (index < 0) {
			index = faces.Length - 1;
		}
		transform.GetChild(0).gameObject.GetComponent<Image>().sprite = faces[index];
	}

	public void Spawn() {
		GameObject.FindObjectOfType<PartCreator> ().Spawn(transform.GetChild (0).gameObject.GetComponent<Image> ().sprite.texture);

	}
}
