using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script to be attached to the hook

public class FollowMousePos : MonoBehaviour {
	
	//mouse position
	private Vector3 mousePos;
	private Rigidbody2D rb;
	//direction
	private Vector2 dir;
	private float moveSpeed = 100f;
	//var to be used in game control script to start the game when player moves the hook
	public static float startGame = 0f;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			dir = (mousePos - transform.position).normalized;
			rb.velocity = new Vector2(dir.x * moveSpeed, dir.y * moveSpeed);
			//to enable fish movements in RandomMovement script
			startGame = 1f;
		}
		else {
			//stop movement if MB not pressed
			rb.velocity = Vector2.zero;
		}
	}
}
