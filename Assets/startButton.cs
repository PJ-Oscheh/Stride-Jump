using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour {

	// Use this for initialization
	void OnMouseDown () {
		Debug.Log ("Mouse Down");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
	

