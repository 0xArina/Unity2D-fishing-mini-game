using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script to be attached to TimerText

public class Timer : MonoBehaviour {
	
	Text timerText;
	public static float timer = 60f;
	
	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0)
			timer = 0;
		timerText.text = Mathf.Round (timer) + " sec";
	}
}
