using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public bool isFiring;
	public BulletController Bullet1;
	public BulletController[] bullets;
	public float bulletSpeed;
	public float timeBetweenShots;
	public Transform firePoint;
	public float bulletDamage = 5;
    public static int bulletAdditive;

	private float shotCounter;


	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(isFiring)
		{
			shotCounter -= Time.deltaTime;
			if(shotCounter <= 0)
			{
				
				shotCounter = timeBetweenShots;
				BulletController newBullet = Instantiate(Bullet1, firePoint.position, firePoint.rotation) as BulletController;
				newBullet.speed = bulletSpeed;
                newBullet.bulletDamage = (int) bulletDamage + bulletAdditive;

			}

		}

		else

		{
			shotCounter = 0;

		}

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Bullet_Damage_UG") 
		{

			Debug.Log ("Collected a pick up");

		}
	
	
	}

}