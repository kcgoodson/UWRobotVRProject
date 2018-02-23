using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHider : MonoBehaviour {

	public GameObject uiToHide;
	bool hide = false;

	public void ToggleHide() {
		hide = !hide;
		Image[] images = uiToHide.GetComponentsInChildren<Image> ();
		Button[] buttons = uiToHide.GetComponentsInChildren<Button> ();
		Text[] texts = uiToHide.GetComponentsInChildren<Text> ();
		foreach (Image i in images) {
			i.enabled = hide;
		}
		foreach (Button b in buttons) {
			b.enabled = hide;
		}
		foreach (Text t in texts) {
			t.enabled = hide;
		}
	}
}
