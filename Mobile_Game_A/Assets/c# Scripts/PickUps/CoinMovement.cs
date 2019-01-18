using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (0, -6 * Time.deltaTime, 0); // This moves the enemy down, we mutilply by time.delta time
		transform.Rotate(0, 360 * Time.deltaTime, 0);     // Make coin rotate
		Destroy (this.gameObject, 2.0f);				 // as we want it to move evey second
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") // If collide with player
		{
		
			ScoreScript.scoreValue += 1;        // Add 1 to script
			GameControl.control.totalCoinCount (1); // Add 1 to total score
			Destroy (gameObject);	                // Destory that object 
		}
	}
}