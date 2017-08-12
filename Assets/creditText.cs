using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class creditText : MonoBehaviour {
	public Text text0;
	public Text text1;
	public Text text2;
	public Transform background;
	public Transform open0;
	public Transform open1;
	public Transform close;
	// Use this for initialization
	void OnMouseDown () {
		text0.text = "";
		text1.text = "";
		text2.text = "Achievement icon: \n https://icons8.com/icon/6050/Medal-First-Place \n \n \n Leaderboard icon: \n https://icons8.com/icon/34141/leaderboard";
		background.transform.position = new Vector2 (0, -0.1f);
		open0.transform.position = new Vector2 (1.5f, -0.6f);
		open1.transform.position = new Vector2 (1.5f, -1.7f);
		close.transform.position = new Vector2 (-1.8f, -3.3f);
	}
}
