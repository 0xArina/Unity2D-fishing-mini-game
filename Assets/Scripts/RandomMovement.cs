using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script to be attached to fish

public class RandomMovement : MonoBehaviour {
	
	public float moveSpeed;
    public Vector3 dir;
    public float turnSpeed;
    float targetAngle;
    Vector3 currentPos;
    bool play=true;
    Vector3 direction;
    
    void Start()
    {
    	//start after player moved the hook with mouse
    	if(FollowMousePos.startGame == 1){
        	dir = Vector3.up;
        	//repeat from 0 sec every 10 
        	InvokeRepeating ("RandomMove", 0f, 10f);
    	}
    }
    
    void RandomMove(){
        play = true;
        direction = new Vector3(Random.Range(-3.0f,3.0f),Random.Range(-4.0f,4.0f),0); 
    }
    
    void Update(){	
	    //start after player moved the hook with mouse
	    if(FollowMousePos.startGame == 1){
	    
	   		//current position 
	        currentPos = transform.position;
	      
		    if(play) {
		    	//calculating direction
		       	dir = direction - currentPos;  
			    dir.z = 0;
			    dir.Normalize ();
			    play = false;
		    }   
		        
        //calculating target position
        Vector3 target = dir * moveSpeed + currentPos; 
        
        //movement from current position to target position
        transform.position = Vector3.Lerp (currentPos, target, Time.deltaTime);
        
        //angle of rotation of gameobject
        targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; 
        
        //rotation from current direction to target direction
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime); 
    }
    }
    
    void OnCollisionEnter2D()
    {
    	//cancel InvokeRepeating
        CancelInvoke ();
        
        //again provide random position in x and y
        direction = new Vector3 (Random.Range (-3.0f, 3.0f), Random.Range (-4.0f, 4.0f), 0); 
        
        play = true;
    }
}
