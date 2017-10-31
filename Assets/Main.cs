using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main : MonoBehaviour {
	// I see you've decided to take a peek at the code! I appreciate any feature you add or bug you fix.
	// However, if your commit is "out of scope," (e.g.: changing it into a first-person racing game), 
	// it will be rejected. However, you can keep your fork and redistribute that. All I ask is that
	// you rename it. If you want to change the game dramatically while keeping the jumper format,
	// perhaps we could implement some sort of "game mode" system.
	// Thanks! -PJBeans

	public static Main Instance { get; private set; }
	public Rigidbody2D rb;
	public Transform platform;
	public GameObject ThePlatform;
	public GameObject Laser;
	public float jumpSpeed;
	public float flingSpeed;
	public float flingSpeedUp;
	float timer = 0.0f; //Timer for menu to disappear
	float timeOut = 3.0f;
	public Text MyText;
	public Text DeadText;
	public Text LeaderboardText;
	public Transform reset;
	public Transform leaderboard;
	public Transform achievements;
	public Transform Menu;
	int jumpCount = 2;
	public static int scoreCount {get; private set;}

	//Color stuff
	public static int colorId { get; set; } //Set by public integer in Colors.cs
	public SpriteRenderer playerSprite;

	int deadCheck = 0;

	// Use this for initialization
	void Start () {
		scoreCount = 2;
		rb = GetComponent<Rigidbody2D> ();
		MyText.text = "Score: " + scoreCount ;
		DeadText.text = "";
		LeaderboardText.text = "";

		//Set the color
		if (colorId == 0) {
			playerSprite.color = new Color (0f, 0f, 0f); //Black
		}
		if (colorId == 1) {
			playerSprite.color = new Color (1f, 0f, 0f); //Red
		}
		if (colorId == 2) {
			playerSprite.color = new Color (1, 1, 0); //Challenge Mode :)
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Movement. 
		// Keyboard movement for quick testing
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

		// Touch screen jump controls
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began & jumpCount > 0 & deadCheck == 0) {
			rb.AddForce (new Vector2 (0, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
			jumpCount = jumpCount - 1;
			scoreCount = scoreCount - 1;
			MyText.text = "Score: " + scoreCount ;
		}
		// Gyroscope controls
		transform.Translate (Input.acceleration.x * 14.0f * Time.deltaTime, 0, 0);

		//Menu
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved)
			Menu.transform.position = new Vector2 (1.9f, 4.65f);
		timer += Time.deltaTime;

		if (timer >= timeOut) {
			Menu.transform.position = new Vector2 (1.9f, 6.0f);
			timer = 0.0f;
		}
		if (Input.GetKey ("n")) {
			Debug.Log ("Press n");
			Menu.transform.position = new Vector2 (1.9f, 4.65f);
			timer += Time.deltaTime;

			if (timer >= timeOut) {
				Menu.transform.position = new Vector2 (1.9f, 6.0f);
				timer = 0.0f;
			}
		}
			
		
				
	}


	void OnCollisionEnter2D (Collision2D col) {
		// Collisions

		// Platform is the initial platform, die is all others. The initial platform musn't be destroyed as it is used as a copy for all other platforms.
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

		// White platforms
		if (col.gameObject.tag == "Die") { 
			Debug.Log ("Collide with Die tag");
			jumpCount = 2;
			scoreCount = scoreCount + 5;
			MyText.text = "Score: " + scoreCount;


			ThePlatform.tag = "Die";
			Instantiate (ThePlatform);
			ThePlatform.tag = "Platform";	
			
		}

		// Chance spawn a laser.
		if (col.gameObject.tag == "Die" & Random.value > 0.9) {
			Debug.Log ("Created with 0.9 chance");
			Instantiate (Laser);
		}

		// Fling and NegFling are not used. Their code is kept incase we find a spot to implement them later.
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

		// This ends the game and handles many achievements.
		if (col.gameObject.tag == "Kill") {
			Debug.Log ("Collide with Kill");
			DeadText.text = "Game Over";
			LeaderboardText.text = "Tap the leaderboard icon to \n submit your score.";
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
			if (scoreCount >= 850) {
				PlayGamesScript.UnlockAchievement (GPGSIds.achievement_so_youre_not_a_rookie);
			}


			// ^ End of Kill.

			// Falling blocks are known internally as lasers.
			if (col.gameObject.tag == "Laser") {
				Debug.Log ("Collide with Laser");
				jumpCount = jumpCount + 1;

			}





		}
	}
}




