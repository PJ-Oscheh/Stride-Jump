using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main : MonoBehaviour {
	public static Main Instance { get; private set; }
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
	public Transform leaderboard;
	public Transform achievements;
	int jumpCount = 2;
	public static int scoreCount {get; private set;}
	int deadCheck = 0;

	// Use this for initialization
	void Start () {
		scoreCount = 2;
		rb = GetComponent<Rigidbody2D> ();
		MyText.text = "Score: " + scoreCount ;
		DeadText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		//Log jumpCount to test double jump. Remove before publishing to Google Play.
		Debug.Log(jumpCount);
		//Movement. 
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
			
		transform.Translate (Input.acceleration.x * 14.0f * Time.deltaTime, 0, 0);


		
				
	}


	void OnCollisionEnter2D (Collision2D col) {

		//Platform is the initial platform, die is all others. The initial platform musn't be destroyed as it is used as a copy for all other platforms.
		if (col.gameObject.tag == "Platform") { 
			Debug.Log ("Collide with Platform tag");
			col.transform.position = new Vector2 (8, -4);
			jumpCount = 2;
			scoreCount = scoreCount + 5;
			MyText.text = "Score: " + scoreCount;
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
		if (col.gameObject.tag == "Die" & Random.value > 0.9) {
			Debug.Log ("Created with 0.9 chance");
			Instantiate (Laser);
		}
		if (col.gameObject.tag == "Fling") {
			Debug.Log ("Collide with Fling");
			jumpCount = 2;
			rb.AddForce (new Vector2 (flingSpeed * Time.deltaTime, flingSpeedUp * Time.deltaTime));
		}
		if (col.gameObject.tag == "NegFling") {
			Debug.Log ("Collide with NegFling");
			jumpCount = 2;
			rb.AddForce (new Vector2 (-flingSpeed * Time.deltaTime, flingSpeedUp * Time.deltaTime));
		}

		//This ends the game and handles many achievements.
		if (col.gameObject.tag == "Kill") {
			Debug.Log ("Collide with Kill");
			DeadText.text = "You died :)";
			deadCheck = 1;
			reset.transform.position = new Vector2 (0, 1);
			leaderboard.transform.position = new Vector2 (-1.4f, -1);
			achievements.transform.position = new Vector2 (1.4f, -1);
			if (scoreCount == 2) {
				Debug.Log ("End game with score 2");
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_testing_the_waters);
			}
			if (scoreCount >= 3) {
				Debug.Log ("Greater or equal to 3");
			}
			if (scoreCount >= 100) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_triple_digits);
			}
			if (scoreCount >= 500) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_high_500);
			}
			if (scoreCount == 999) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_not_today);
			}
			if (scoreCount >= 1000) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_1k);
			}
			if (scoreCount >= 2000) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_the_millennium);
			}
			if (scoreCount <= -1) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_other_way_ya_goose);
			}
			if (scoreCount >= 50) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_baby_steps);
			}
			if (scoreCount >= 150) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_150);
			}
			if (scoreCount >= 200) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_youre_getting_the_hang_of_it);
			}
			if (scoreCount == 199) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_o_captain_my_captain);
			}


			// ^ End of Kill.
			if (col.gameObject.tag == "Laser") {
				Debug.Log ("Collide with Laser");
				jumpCount = jumpCount + 1;

			}





		}
	}
}




