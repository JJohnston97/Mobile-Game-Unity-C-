/// @Enemy.cs
/// @brief handles the Enemy class and anything to do with non player objects
/// Author Jamie Johnston

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	float m_maxHealth = 4f;		// The max health an enemy 1 can have
	float m_curHealth = 0f;		// Current health of that enemy
	bool indestructable = false;// Can the object be destroyed
	public GameObject Coin;     // Coin gamebject

    public GameObject Dincrease;    // Game Object used for Damage increase
    public GameObject PDincrease;   // Game Object used for Periminant Damage increase
    public GameObject diamond;      // Game Object used for Diamond

	public bool m_enemyDeath;       // Bool to see if enemy is dead or not

	void Start () 
	{     
		m_curHealth = m_maxHealth;  // Sets the current health to the max health at the time of them spawning
        m_enemyDeath = false;		// Enemy is not deads
	}

	void Update () 
	{
		transform.Translate (0, -6 * Time.deltaTime, 0); // This moves the enemy down, we mutilply by time.delta time
		Destroy (this.gameObject, 2.0f);				 // as we want it to move evey second	
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.gameObject.tag == "Player") 		// If the enemy collides with an object with tag player
		{
			Destroy (GameObject.FindWithTag ("Player"));    // Find the object with tag player, destory it
            GameControl.control.playerLives -= 1;           // Accsess game control with control , -1 from player lives
            PlayerPrefs.SetInt("Lives", GameControl.control.playerLives);   // Save the now total of player lives
            GameControl.control.endGame();                                  // Call the end game function in side game control        
		}
	}

	public void doDamage(int _damage)       // Do damage to enemys function
	{
		//Debug.Log (_damage);
		if( indestructable )              // If the enemy is indestructable return nothing
		{
			return;
		}
        m_curHealth -= _damage;         // Enemy currenly health take away damage done 

        if ( m_curHealth <= 0 )         // If currentl health is less than or equal to 0 
		{
            m_curHealth = 0;                     // Current health set to 0
            m_enemyDeath = true;                 // Enemy death is true
			GameControl.control.addEXP (0.2f);   // Add xp in game control 
			Destroy (gameObject);                // Destroy that game object
			int coinChance;                      // Coin chance to spawn
            int pickUpSpawn;                     // Pick up chance to spawn 
            pickUpSpawn = Random.Range(0, 100);  // Random number between 1 and 100
			coinChance = Random.Range (0, 2);    // Random number between 1-2
		if (coinChance == 1) 
			{
				spawnCoin ();                   // Spawn coin if coin chance is equal to 1
			
			}
        if (pickUpSpawn > 90 )
            {
                spawnPickUp();                  // If pick up is greater than 90 spawn pick up function
            }
		}
	}
	
	void spawnCoin()
	{
	
		Instantiate (Coin, transform.position, Quaternion.identity); // Coin to move down the screen
	
	}

    void spawnPickUp()                  // Spawn Pick ups
    {
        int num;
        num = Random.Range(0, 3);

        if (num == 0)                   // if the num is equal to 0
        {
            Debug.Log("Spawned 1");
            Instantiate(Dincrease, transform.position, Quaternion.identity);    //Damage increase
        }
        if (num == 1)                   // if the num is equal to 1
        {
            Debug.Log("Spawned 2");
            Instantiate(PDincrease, transform.position, Quaternion.identity);   //Damage increase
        }
        if (num == 2)                   // if the num is equal to 2
        {
            Debug.Log("Spawned 3");
            Instantiate(diamond, transform.position, Quaternion.identity);   //Diamond
        }
        

    }
}
