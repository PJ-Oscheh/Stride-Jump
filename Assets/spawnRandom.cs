using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandom : MonoBehaviour {

	float x;
	float y;
	Vector2 pos;
	// Use this for initialization
	void Start () {
		x = Random.Range (-2, 2);
		y = Random.Range (4, -4);
		pos = new Vector2 (x, y);
		transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
