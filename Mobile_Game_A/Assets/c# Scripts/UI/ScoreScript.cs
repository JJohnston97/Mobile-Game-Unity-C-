using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static ScoreScript scoreSS;
	public static int scoreValue = 0;
	Text score;
	// Use this for initialization

	void Start () 
	{
        
		score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		score.text = scoreValue.ToString();
        if (scoreValue > 200)
        {
            ShaderOn();

        }
        if (scoreValue >= 350)
        {
            ShaderOff();

        }
    }
    void ShaderOn()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShaderEffect>().enabled = true;
    }

    void ShaderOff()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShaderEffect>().enabled = false;
    }
}
