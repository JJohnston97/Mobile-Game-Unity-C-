using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour {

    public GameObject bb;   // bullets object
	public string m_type;   // Type of pick up
	
	void Update () 
	{
        transform.Translate(0, -4 * Time.deltaTime, 0); // Move pick up down the screen
        Destroy(this.gameObject, 5.0f);                 // Destroy after 5 seconds
	}

	void OnCollisionEnter(Collision pcol)
	{
		if (pcol.gameObject.tag == "Player")    // If they collide with player
		{
            bb = GameObject.FindGameObjectWithTag("Bullets");       // Find bullet objects

           
			switch (m_type) // Depending on pick up type
			{
			case "DamageIncrease":
				Debug.Log ("Hit Damage Increase");
				gameObject.GetComponent<MeshRenderer> ().enabled = false; //  Turn the render off
                StartCoroutine(_damageTimer(GameObject.FindGameObjectWithTag("Gun").GetComponent<GunController>())); // Find the gun controller that contains bullets
                    break;
			case "Diamond":
                    ScoreScript.scoreValue += 10;   // Add 10 to score
                    Debug.Log("Hit Diamond");
                    Destroy(gameObject);            // Destory object
				break;
			case "PDincrease":
				Debug.Log ("Hit Bullet Damage increase");
                GameObject.FindGameObjectWithTag("Gun").GetComponent<GunController>().bulletDamage += 2; // Add two to bullet damage
                 Destroy(gameObject);
				break;
			}
		}
	}

	IEnumerator _damageTimer(GunController _bdamage)
	{
		Debug.Log ("DAMAGE BOOST");
		_bdamage.bulletDamage += 2; // Increase the damage by 2
        Debug.Log(_bdamage.bulletDamage);
        Destroy (gameObject);      // Destory the game object
		yield return new WaitForSeconds (10);       // Wait for 10 seconds
        Debug.Log(_bdamage.bulletDamage);           
	}
}
