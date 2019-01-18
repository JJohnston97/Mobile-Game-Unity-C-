using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramesPerSecond : MonoBehaviour {

	Rect fpsRect;           // New rect for fps
	GUIStyle style;         // GUI style for font size
	float fps;              // Float of FPS 

	void Start () 
	{
		fpsRect = new Rect (50, 50, 400, 100);  // Where on the screen
		style = new GUIStyle ();                // Make new GUI style
		style.fontSize = 30;                    // Set the font size

		StartCoroutine (RecalculateFPS ());     // Start coroutine of fps calc to work every section
	}
	
	private IEnumerator RecalculateFPS()
	{
	
		while (true) 
		{
			fps = 1 / Time.deltaTime;               // Fps every second rather than every frame
			yield return new WaitForSeconds(0.5f);  // Wait half second before recalc
		}
	
	}


	void OnGUI()
	{
		GUI.Label(fpsRect, "FPS: " + string.Format("{0:0.0}",fps),style); // Convert float into GUI 
	}
}
