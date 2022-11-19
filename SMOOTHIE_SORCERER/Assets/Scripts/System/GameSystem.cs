using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    static GameSystem _system;
    public GameObject GameScoreCanvas;
    private GameCompletion GameCompletion;
    public TMP_Text ScoreText;
    public float value;
    public int Level;
    public float Score = 0;


    void Start()
    {
        Time.timeScale = 1f;
        ScoreText.text = "$0";
        var adding = gameObject.GetComponent<GameCompletion>().MaxCustomers;
        
    }
    
    void Update()
    {
        
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
    

    public void IncreaseScore()
    {
        Score += value;
        ScoreText.text =("$ " + Score.ToString());
    }

    public void OnVegetableCut()
  {
    //IncreaseScore();
    Debug.Log("Cut");
    ScoreText.text = Score.ToString();
  }
}
