using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Sprite[] faces;
	List<Material> paintSwatches;
	Sprite[] spriteSheet;
	public Image face;
	public GameObject partSpawner;
	public GameObject basePart;
	int index = 0;

	void Start() {
		paintSwatches = new List<Material> ();
		faces = Resources.LoadAll<Sprite>("RobotParts");
		/*faces = new Sprite[temp.Length];
		for (int i = 0; i < temp.Length; i++) {
			faces [i] = temp [i] as Sprite;
		}*/
		Change (0);
	}

	public void Change(int n) {
		index += n;
		if (index >= faces.Length) {
			index = 0;
		} else if (index < 0) {
			index = faces.Length - 1;
		}
		face.sprite = faces[index];
	}



	/*public void Spawn() {
		Material facePaint = MixPaint(face.sprite.texture);
		GameObject g = Instantiate (basePart, partSpawner.transform.position, partSpawner.transform.rotation);
		g.GetComponent<MeshRenderer> ().material = facePaint;
	}

	Material MixPaint(Texture t) {
		for (int i = 0; i < paintSwatches.Count; i++) {
			if (paintSwatches [i].mainTexture == t) {
				return paintSwatches [i];
			}
		}
		Material facePaint = new Material (Shader.Find("Diffuse"));
		facePaint.mainTexture = t;
		paintSwatches.Add (facePaint);
		return facePaint;
	}*/
}
