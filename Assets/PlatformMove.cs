using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {
	public Transform farEnd;
	private Vector2 frometh;
	private Vector2 untoeth;
	public float secondsForOneLength = 20f;

	// Use this for initialization
	void Start () {
		frometh = transform.position;
		untoeth = farEnd.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.Lerp (frometh, untoeth, Mathf.SmoothStep (0f, 1f, Mathf.PingPong (Time.time / secondsForOneLength, 1f)));

	}
}
