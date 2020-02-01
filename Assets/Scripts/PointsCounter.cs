using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script to be attached to the hook

/* 
	      POINTS COUNTER:
	orange fish  	+10 points 
	blue fish 		+5 points
	red fish 	 	+2 points 
	yellow fish  	end of the game, 0 points
	
 */

public class PointsCounter : MonoBehaviour {

	public GameObject redPrefab, bluePrefab, orangePrefab;
	static public float endGame = 0f;
	
	void OnCollisionEnter2D(Collision2D col) {
    	if(col.gameObject.tag == "red") {
    		
    		//accessing score value through Scoring script
      		Scoring.scoreValue += 2;
      		Destroy(col.gameObject);
      		
      		Vector2 newPos = new Vector2 (Random.Range (-7, 7), Random.Range (-3, 3));
    
      		//creates the random object at the random 2D position
      	 	Instantiate (redPrefab, newPos, transform.rotation);
		}
		
		if(col.gameObject.tag == "blue") {
    		//accessing score value through Scoring script
      		Scoring.scoreValue += 5;
      		Destroy(col.gameObject);
      		Vector2 newPos = new Vector2 (Random.Range (-7, 7), Random.Range (-3, 3));
    
	      	//Creates the random object at the random 2D position.
	        Instantiate (bluePrefab, newPos, transform.rotation);
	    }
		
		if(col.gameObject.tag == "orange") {
    		//accessing score value through Scoring script
      		Scoring.scoreValue += 10;
      		Destroy(col.gameObject);
      		
      		Vector2 newPos = new Vector2 (Random.Range (-7, 7), Random.Range (-3, 3));
    
	      	//Creates the random object at the random 2D position.
	        Instantiate (orangePrefab, newPos, transform.rotation);
	     }
		
		if(col.gameObject.tag == "yellow") {
			//to use this variable in GameControl script
      		endGame = 1f;
      		Destroy(col.gameObject);
		}
    }
    
    void respawn(){
		//Defines the min and max ranges for x and y
        Vector2 pos = new Vector2 (Random.Range (-7, 7), Random.Range (-3, 3));
    
      	//Creates the random object at the random 2D position
        Instantiate (redPrefab, pos, transform.rotation);
    }
}
