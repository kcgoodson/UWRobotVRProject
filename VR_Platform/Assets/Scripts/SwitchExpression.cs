using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchExpression : MonoBehaviour {
	public Material[] myMaterials;
	//public GameObject Object;
	private int count = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.N)){
			count ++;
			if(count >= myMaterials.Length){
				count = 0;
			}
		}
		if(Input.GetKeyDown(KeyCode.B)){
			count --;
			if(count < 0){
				count = myMaterials.Length - 1;
			}
		}

		gameObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = myMaterials[count];
	}
}
