using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    static GameSystem _system;
    public GameObject GameScoreCanvas;
    private GameCompletion GameCompletion;
    public TMP_Text ScoreText;
    public TMP_Text HappyCustomerText;
    public float value;
    public int happyCurrent;
    public int maxHappy;
    public int Level;
    public float Score = 0;
    public bool isEndless;

    public int earnBack;


    void Start()
    {
        GameCompletion = GetComponent<GameCompletion>();
        
        earnBack = 0;
        Time.timeScale = 1f;
        ScoreText.text = "$0";

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Endless1")
        {
            isEndless = true;
            maxHappy = 5;
            happyCurrent = maxHappy;
            HappyCustomerText.text = happyCurrent + "/" + maxHappy;
        }else 
            HappyCustomerText.gameObject.SetActive(false);
        
        

        
    }
    
    void Update()
    {
        if (isEndless)
        {
             
            if (earnBack == 3)
            {
                happyCurrent ++;
                earnBack = 0;
            }
             
             HappyCustomerText.text = happyCurrent + "/" + maxHappy;

             if (happyCurrent == 0)
             {
                //end state setting
                GameCompletion.MaxCustomers = GameCompletion.CurrentCustomers;
             }
        }

        
           
    }

    public static GameSystem System
    {
        get
        {
            if(_system == null)
            {
                _system = GameObject.FindObjectOfType<GameSystem>();

                if (_system == null)
                {
                    GameObject container = new GameObject("GameSystem");
                    _system = container.AddComponent<GameSystem>();
                }
            }

            return _system;
        }
    }
    

    public void IncreaseScore(float addingValue)
    {
        Score += addingValue;
        ScoreText.text =("$" + Score.ToString());
    }

    public void DecreaseHappyCustomers (int subtract)
    {
        happyCurrent -= subtract;
    }

    public void OnVegetableCut()
  {
    //IncreaseScore();
    Debug.Log("Cut");
  }
}
