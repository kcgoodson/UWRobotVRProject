using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCreator : MonoBehaviour {

	public GameObject basePart;
	List<Material> paintSwatches;

	void Start() {
		paintSwatches = new List<Material> ();
	}

	public void Spawn(Texture t) {
		Material facePaint = MixPaint(t);
		GameObject g = Instantiate (basePart, transform.position, transform.rotation);
		g.GetComponent<MeshRenderer> ().material = facePaint;
		g.transform.localScale *= 0.35f;
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
	}
}