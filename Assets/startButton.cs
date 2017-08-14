using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour {
	public Transform objaudio;
	// Use this for initialization
	void OnMouseDown () {
		Debug.Log ("Mouse Down");
		AudioSource audio = objaudio.GetComponent<AudioSource> ();
		audio.Play ();
		audio.Play (44100);
		DontDestroyOnLoad (objaudio);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);


	}
}
	

