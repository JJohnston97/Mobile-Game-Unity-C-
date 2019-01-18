using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

	public GameObject enemy1;       // Enemy 1 Objects
	public GameObject enemy2;       // Enemy 2 Objects
	public float repeatTime = 1f;   // How often they repeat
	int spawnPer;                   // Spawn percentage
    int spawnChance = 92;           // Spawn chance
    float timer = 0;                // Timer for how often they spawn

	void Start()
	{
	
		InvokeRepeating ("spawnEnemy1", 1f, repeatTime); // Enemy function constantly calling every 1 second

	}

	void Update()
	{
        timer += Time.deltaTime;            // break down into seconds
        if (timer >= 5.0f)                  // If timer is greater than 5
        {
            spawnPer = Random.Range(1, 101); // Roll random number

            if (spawnPer > spawnChance)     // If the number rolled if bigger than 92
            {

                spawnEnemy2();              // Spawn second enemy
             
            }
            if (ScoreScript.scoreValue > 200)    // If the score of the player is greater than 200 the spawn chance of enemy two is increased 
            {
                spawnChance = 75;
            }

            timer = 0;
        }
       
		
	}
	void spawnEnemy1()          // Spawn enemy one and move down the screen
	{
	
		Instantiate (enemy1, transform.position, Quaternion.identity);
	}


	void spawnEnemy2()          // Spawn enemy two and move down the screen
	{
		Instantiate (enemy2, transform.position, Quaternion.identity);

	}
}
