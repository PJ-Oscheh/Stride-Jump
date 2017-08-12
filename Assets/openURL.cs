using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openURL : MonoBehaviour {
	public string urlHere;
	// Open the URL.
	void OnMouseDown () {
		Debug.Log ("clicked");
		Application.OpenURL (urlHere);
	}
}
	

