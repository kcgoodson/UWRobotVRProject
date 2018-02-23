using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public void ReloadScene() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void ChangeScene() {
		int next = SceneManager.GetActiveScene ().buildIndex + 1;
		if (next >= SceneManager.sceneCountInBuildSettings) {
			next = 0;
		}
		SceneManager.LoadScene (next);
		Debug.Log (next);
	}
}
