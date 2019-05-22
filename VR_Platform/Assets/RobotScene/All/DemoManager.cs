using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoManager : MonoBehaviour {

	AudioSource me;
	int numScenes; 

	void Start() {
		me = GetComponent<AudioSource> ();
		numScenes = SceneManager.sceneCountInBuildSettings;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Equals)) {
			Debug.Log ("NEXT");
			int next = SceneManager.GetActiveScene ().buildIndex + 1;
			Debug.Log (next);
			if (next < numScenes) {
				SceneManager.LoadScene (next);
			}
		} else if (Input.GetKeyDown (KeyCode.Minus)) {
			Debug.Log ("BEFORE");
			int before = SceneManager.GetActiveScene ().buildIndex - 1;
			Debug.Log (before);
			if (before >= 0) {
				SceneManager.LoadScene (before);
			}
		}
	}

	public void Win() {
		me.Play ();
	}
}
