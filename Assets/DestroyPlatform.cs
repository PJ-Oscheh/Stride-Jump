using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Die")
			Destroy(col.gameObject);
		if (col.gameObject.tag == "Platform")
			col.transform.position = new Vector2 (8, -4);
	}
}
