using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour {
    TextMesh textMesh;
    float theTime;
    float displayTime;
    public float totalTime;
    public float speed;
    public bool playing;

	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMesh>();

	}
	
	// Update is called once per frame
	void Update () {
        if (playing == true)
        {
            theTime += Time.deltaTime * speed;
            displayTime = totalTime - theTime;
            string minutes = Mathf.Floor((displayTime % 3600) / 60).ToString("00");
            string seconds = (displayTime % 60).ToString("00");
            textMesh.text = minutes + ":" + seconds;
        }
	}
}
