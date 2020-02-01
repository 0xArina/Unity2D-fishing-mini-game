using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script to be attached to GameControl g.o.

public class GameControl : MonoBehaviour {
	
	public GameObject timeIsUp, restartButton, gameOver;
	
	// Use this for initialization
	void Start () {
		timeIsUp.gameObject.SetActive(false);
		restartButton.gameObject.SetActive(false);
		gameOver.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//if var timer from Timer script <=0
		if(Timer.timer <=0){
			//stop timer
			Time.timeScale = 0;
			timeIsUp.gameObject.SetActive(true);
			//show restart button
			restartButton.gameObject.SetActive(true);	
		}
		//else if var endGame from PointsCounter script == 1
		else if(PointsCounter.endGame == 1){	
			//stop timer
			Time.timeScale = 0;
			//show restart button
			restartButton.gameObject.SetActive(true);
			gameOver.gameObject.SetActive(true);
			PointsCounter.endGame = 0;
		}
	}
	
	public void restartScene() {
		timeIsUp.gameObject.SetActive(false);
		restartButton.gameObject.SetActive(false);
		
		SceneManager.LoadScene("SampleScene");
		
		Scoring.scoreValue = 0;
		Timer.timer = 60f;
		//FollowMousePos.startGame = 0;
		
		if(FollowMousePos.startGame == 1){
			Time.timeScale = 1;
			//accessing var timer through Timer script
			Timer.timer = 60f;
		}	
		FollowMousePos.startGame = 0f;		
	}
}
