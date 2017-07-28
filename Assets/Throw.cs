using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {
	public Rigidbody2D rb;
	public float throwVal;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2 (throwVal * Time.deltaTime, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
