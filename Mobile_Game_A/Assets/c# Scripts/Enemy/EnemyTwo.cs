using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0, -10 * Time.deltaTime, 0); // This moves the enemy down, we mutilply by time.delta time
        Destroy(this.gameObject, 2.0f);                  // as we want it to move evey second	
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")     // If collide with player
        {

            Destroy(col.gameObject);            // Destory game object
            GameControl.control.playerLives--;  // Take one from player lives
            PlayerPrefs.SetInt("Lives", GameControl.control.playerLives);   // Save it
            GameControl.control.endGame();      // End the game
        }
    }
}
