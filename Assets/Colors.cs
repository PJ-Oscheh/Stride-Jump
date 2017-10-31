using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour {
	public SpriteRenderer playerSprite;
	public int setColor;
	// Use this for initialization
	void OnMouseDown () {
		Debug.Log ("Clicked");
		Main.colorId = setColor;
		Debug.Log("ColorId: " + Main.colorId);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
