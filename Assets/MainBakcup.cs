using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainBakcup : MonoBehaviour {
	public Rigidbody2D rb;
	public Transform platform;
	public GameObject ThePlatform;
	public GameObject Laser;
	public float jumpSpeed;
	public float flingSpeed;
	public float flingSpeedUp;
	public Text MyText;
	public Text DeadText;
	public Transform reset;
	int jumpCount = 2;
	int scoreCount = 2;
	int deadCheck = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		MyText.text = "Score: " + scoreCount ;
		DeadText.text = "";
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
		if (Input.GetKeyDown ("space") & jumpCount > 0 & deadCheck == 0) {
			rb.AddForce (new Vector2 (0, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
			jumpCount = jumpCount - 1;
			scoreCount = scoreCount - 1;
			MyText.text = "Score: " + scoreCount ;
		}
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began & jumpCount > 0 & deadCheck == 0) {
			rb.AddForce (new Vector2 (0, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
			jumpCount = jumpCount - 1;
			scoreCount = scoreCount - 1;
			MyText.text = "Score: " + scoreCount ;
		}
			
		transform.Translate (Input.acceleration.x * 15.0f * Time.deltaTime, 0, 0);
		
		
		
				
	}


	void OnCollisionEnter2D (Collision2D col) {

		//Platform is the initial platform, die is all others. The initial platform musn't be destroyed as it is used as a copy for all other platforms.
		if (col.gameObject.tag == "Platform") { 
			Debug.Log ("Collide with Platform tag");
			col.transform.position = new Vector2 (8, -4);
			jumpCount = 2;
			scoreCount = scoreCount + 5;
			MyText.text = "Score: " + scoreCount ;
			ThePlatform.tag = "Die";
			Instantiate (ThePlatform);
			ThePlatform.tag = "Platform";
		}
		if (col.gameObject.tag == "Die") { 
			Debug.Log ("Collide with Die tag");
			jumpCount = 2;
			scoreCount = scoreCount + 5;
			MyText.text = "Score: " + scoreCount;
			//Chance spawn a block

				ThePlatform.tag = "Die";
				Instantiate (ThePlatform);
				ThePlatform.tag = "Platform";	
			
		}
		if (col.gameObject.tag == "Die" & Random.value > 0.8) {
			Debug.Log ("Created with 0.8 chance");
			Instantiate (Laser);
		}
		if (col.gameObject.tag == "Fling") {
			Debug.Log ("Collide with Fling");
			jumpCount = 2;
			rb.AddForce (new Vector2(flingSpeed * Time.deltaTime, flingSpeedUp * Time.deltaTime));
}
		if (col.gameObject.tag == "NegFling") {
			Debug.Log ("Collide with NegFling");
			jumpCount = 2;
			rb.AddForce (new Vector2(-flingSpeed * Time.deltaTime, flingSpeedUp * Time.deltaTime));
		}
		if (col.gameObject.tag == "Kill") {
			Debug.Log ("Collide with Kill");
			DeadText.text = "You died :)";
			deadCheck = 1;
			reset.transform.position = new Vector2 (0, 1);
		}
		if (col.gameObject.tag == "Laser") {
			Debug.Log ("Collide with Laser");
			jumpCount = jumpCount + 1;

		}





}
}



