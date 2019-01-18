using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl control;  // Allows access to the game control script through GameControl.control

	public float m_exp;			        // Player Xp
	public static int m_coinCount;		// Total Coin Count
	public int m_playerLevel = 0;	    // Player level
	BulletController bcontrol;          // Access to the Bullet controller
    bool gameHasEnded = false;          // Game has finished bool
    public static bool GameIsPaused = false;    // Is the game paused
    public GameObject pauseMenuUI;              // Object for pause canvis
    public GameObject endGameMenu;              // Object for end game canvis
    public Button Resume;                       // Resume game object
    public Button MenuButton;                   // Return to menu
    public Button MenuButton2;                  // Menu from death screen
    public Button Quit;                         // Quit game button

    public int playerLives = 2;                 // Player lives

  
    void Start ()
	{
        Screen.orientation = ScreenOrientation.Portrait;            // Set screen Orientation to portrait
        bcontrol = control.GetComponent<BulletController> ();       // Get bullet controller script
        pauseMenuUI.SetActive(false);                               // Turn pause menu off
       

    }
	void Awake () 
	{
		if (control == null) 
		{
			control = this;
		} 
		else if (control != this) 
		{
			Destroy (gameObject);
		}
		m_coinCount = PlayerPrefs.GetInt ("Total Coins");    // When game starts get total coins	                                  
		m_exp = PlayerPrefs.GetFloat ("Player XP");          // Get Player xp
		m_playerLevel = PlayerPrefs.GetInt ("Player Level"); // Get player lvl
        playerLives = PlayerPrefs.GetInt("Lives");           // Get player lives
	}
		
	void Update () 
	{
        Debug.Log(playerLives);
	}

	public void addEXP(float _exp)
	{
		m_exp += _exp;                              // Current xp add new xp
		PlayerPrefs.SetFloat ("Player Xp", m_exp);  // Set new xp after xp added
		PlayerPrefs.Save ();                    

		if (m_exp == 100)                       // If player xp is equal to 100 level up
		{
			LevelUp ();                         // Level up function
		}
	}

	public void totalCoinCount (int _coins)         // Total coin count
	{
	
		m_coinCount += _coins;                              // Currenly coins add new coins
		PlayerPrefs.SetInt ("Total Coins", m_coinCount);    //End of game save
		PlayerPrefs.Save ();                                // Save
	
	}

	public void LevelUp()       // Player level up
	{

		m_playerLevel = +1;         // Add 1 to player level
		bcontrol.bulletDamage += 2; // Add 2 to bullet damage 
		PlayerPrefs.SetInt ("Player Level", m_playerLevel); // Set players level
		PlayerPrefs.Save ();                                // Save it
	}

    public void endGame()       // End game / pause function
    {
        if (playerLives != 0)       // If players lives are not 0
        {
            gameHasEnded = true;        
            pauseMenuUI.SetActive(true);    // Set pause menu as true
            Debug.Log("GameOver");          // Output game over
            Time.timeScale = 0f;            // Freeze the game
            Resume.onClick.AddListener(() =>      
             {
                 Restart();                     // If you click resume then restart the game   
                 pauseMenuUI.SetActive(false);
             });
            MenuButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1.0f;              // Set time scale back to normal
                pauseMenuUI.SetActive(false);       // turn off the pause menu
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Load game menu
            });
            Quit.onClick.AddListener(() =>
            {
                pauseMenuUI.SetActive(false);       // Pause menu is false
                Application.Quit();                 // close the game
            });

        }
        else if (playerLives == 0)              // If players lives are equal to 0
        {
            endGameMenu.SetActive(true);        // End game is true
                PlayerPrefs.SetInt("Lives", 2); // Lives set back to 2
                PlayerPrefs.Save();             // Save

            MenuButton2.onClick.AddListener(() =>
            {
                Time.timeScale = 1.0f;            // Set time scale back to 1 to run menu
                endGameMenu.SetActive(false);       // Turn end menu off
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Load main menu
            });


        }
        
    }

   public void Restart()
    {
        Time.timeScale = 1f;        // Set time scale back to normal
        gameHasEnded = false;       // game has not ended
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);  // Load the game scene again
      
    }

}