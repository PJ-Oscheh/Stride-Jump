using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createLaser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (Random.value > 0.9) {
			Debug.Log ("Created with 0.8 chance");
		}
	}
}
		
		
	

