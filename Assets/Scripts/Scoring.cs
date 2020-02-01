using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script to be attached to ScoreText 

public class Scoring : MonoBehaviour {

	public static int scoreValue = 0;
	Text score;

	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "score: " + scoreValue;
	}
}
