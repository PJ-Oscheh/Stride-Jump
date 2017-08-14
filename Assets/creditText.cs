using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class creditText : MonoBehaviour {
	public Text text0;
	public Text text1;
	public Text text2;

	// Window
	public Transform background;
	public Transform open0;
	public Transform open1;
	public Transform open2;
	public Transform open3;
	public Transform close;
	public Transform tweetTweet;
	public Transform ytIcon;
	public Transform ytIconPaul;

	// Move buttons to avoid accidental presses [as background lacks a BoxCollider2D ]
	public Transform start;
	public Transform rate;
	public Transform howToPlay;
	// Use this for initialization
	void OnMouseDown () {
		text0.text = "";
		text1.text = "Game by PJBeans \n \n \n Music by Paul 'Lucky Luis' Priebe";
		text2.text = "Achievement icon: \n https://icons8.com/icon/6050/Medal-First-Place \n \n \n Leaderboard icon: \n https://icons8.com/icon/34141/leaderboard \n \n \n This game is open source. Feel free to change it: \n https://github.com/PJBeans/Instinct-Jump \n \n \n By playing this game, you agree \n to the GNU General Public License v3.0:";
		background.transform.position = new Vector2 (0, -0.1f);
		open0.transform.position = new Vector2 (1.5f, 2.57f);
		open1.transform.position = new Vector2 (1.5f, 1.64f);
		open2.transform.position = new Vector2 (1.5f,0.55f);
		open3.transform.position = new Vector2 (1.5f, -0.41f);
		close.transform.position = new Vector2 (-1.8f, -3.3f);
		tweetTweet.transform.position = new Vector2 (-1.15f, -1.3f);
		ytIcon.transform.position = new Vector2 (1.15f, -1.3f);
		ytIconPaul.transform.position = new Vector2 (0, -2.5f);
		start.transform.position = new Vector2 (0, 7);
		rate.transform.position = new Vector2 (0, 8);
		howToPlay.transform.position = new Vector2 (0, 9);
	}
}
