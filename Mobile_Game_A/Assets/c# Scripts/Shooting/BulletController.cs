using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	public int bulletDamage;
	public GameObject gun;
	GunController gcontrol;

	void Start () 
	{
		gun = GameObject.FindGameObjectWithTag ("Gun");
		gcontrol = gun.GetComponent<GunController> ();
		//bulletDamage = 12;
	}

	// Update is called once per frame
	void Update ()
    {
		damageLevel ();
		transform.Translate(Vector3.up * speed * Time.deltaTime);
		Destroy(this.gameObject, 0.8f);
	}



	void OnCollisionEnter (Collision col)
	{
		Enemy _health = col.gameObject.GetComponent<Enemy>();

		if (col.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy1")) 
		{
			_health.doDamage (bulletDamage);
			Destroy(gameObject);
		}
        if (col.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy2"))
        {
            Destroy(gameObject);
        }
	}

	public void addDamage(int _add)	// If collide with charm call this function from pick ups
	{
		bulletDamage += _add;
	}

	void damageLevel()
	{
	 
		switch (bulletDamage) 
		{
		case 2:
			gcontrol.Bullet1 = gcontrol.bullets [0];             
			break;
		case 4:
			gcontrol.Bullet1 = gcontrol.bullets [1];             
			break;
		case 6:
			gcontrol.Bullet1 = gcontrol.bullets [2];              
                break;
		case 8:
            gcontrol.Bullet1 = gcontrol.bullets [3];
                break;
		case 10:
			gcontrol.Bullet1 = gcontrol.bullets [4];
			break;
		case 12:
			gcontrol.Bullet1 = gcontrol.bullets [5];
			break;
		case 14:
			gcontrol.Bullet1 = gcontrol.bullets [6];
			break;
		case 16:
			gcontrol.Bullet1 = gcontrol.bullets [7];
			break;
		case 18:
			gcontrol.Bullet1 = gcontrol.bullets [8];
			break;
		case 20:
			gcontrol.Bullet1 = gcontrol.bullets [9];
			break;
		case 22:
			gcontrol.Bullet1 = gcontrol.bullets [10];
			break;
		case 24:
			gcontrol.Bullet1 = gcontrol.bullets [11];
			break;
		case 26:
			gcontrol.Bullet1 = gcontrol.bullets [12];
			break;
		case 28:
			gcontrol.Bullet1 = gcontrol.bullets [13];
			break;
		case 30:
			gcontrol.Bullet1 = gcontrol.bullets [14];
			break;
		case 32:
			gcontrol.Bullet1 = gcontrol.bullets [15];
			break;
		case 34:
			gcontrol.Bullet1 = gcontrol.bullets [16];
			break;
		case 36:
			gcontrol.Bullet1 = gcontrol.bullets [17];
			break;
		case 38:
			gcontrol.Bullet1 = gcontrol.bullets [18];
			break;
		case 40:
			gcontrol.Bullet1 = gcontrol.bullets [19];
			break;

		}
	}
}