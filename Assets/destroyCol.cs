using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCol : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player" & this.gameObject.tag == "Die")
			Destroy (gameObject, 0.2f);
	}

}
