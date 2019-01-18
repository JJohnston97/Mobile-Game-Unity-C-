using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{

    public Button play;
    public Button exit;
    public Button DamageUp;



    public int dLevelInc;


    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        dLevelInc = 100;

        play.onClick.AddListener(() =>
       {

           UnityEngine.SceneManagement.SceneManager.LoadScene("MG_A");
       });

        exit.onClick.AddListener(() =>
        {

            Application.Quit();

        });
      }


    void damageLevelIncrease()
      {

          if (GameControl.m_coinCount >= dLevelInc)
          {
              GameControl.m_coinCount -= dLevelInc;

              GunController.bulletAdditive += 2;

          }
      }


 }