using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {
	public Transform audio;
	public GameObject audPlat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		Debug.Log ("Clicked");
		DontDestroyOnLoad (audio);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		Destroy (audPlat);
	}
}
