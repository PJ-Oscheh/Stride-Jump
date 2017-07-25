using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public Rigidbody2D rb;
	public Transform platform;
	public GameObject ThePlatform;
	public float jumpSpeed;
	int jumpCount = 2;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Log jumpCount to test double jump. Remove before publishing to Google Play.
		Debug.Log(jumpCount);
		//Movement. Remap to gyroscope for mobile.
		Vector2 pRight = transform.TransformDirection(Vector2.right);
		if (Input.GetKey ("a"))
			rb.AddForce(-pRight * 500 * Time.deltaTime);
		if (Input.GetKey ("d"))
			rb.AddForce(pRight * 500 * Time.deltaTime);
		if (Input.GetKeyDown ("space") & jumpCount > 0) {
			rb.AddForce (new Vector2 (0, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
			jumpCount = jumpCount - 1;
		}
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began & jumpCount > 0) {
			rb.AddForce (new Vector2 (0, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
			jumpCount = jumpCount - 1;
		}
			
		transform.Translate (Input.acceleration.x * 0.5f, 0, 0);
		
		
		
				
	}


	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Platform") {
			Debug.Log ("Collide with Platform tag");
			jumpCount = 2;
			Instantiate (ThePlatform);

		
}
}
}
