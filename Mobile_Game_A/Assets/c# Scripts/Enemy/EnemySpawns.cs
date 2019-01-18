using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour {

	public Vector3 m_position;  // Position of spawn

	void Start () 
	{
		m_position = gameObject.transform.position; // Takes the position of the parent gameObject	
	}												// To set as location for spawn

	void Update () 
	{
		
	
	}
}
