using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    static GameSystem _system;
    public GameObject GameScoreCanvas;
    public TMP_Text ScoreText;
    public float value;
    public FinishedSmoothie finishedSmoothie;

    void Start()
    {
        ScoreText.text = " ";
        //value = GameObject.FindGameObjectWithTag("FinishedSmoothie");//finishedSmoothie.SmoothieValue;
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
    public float Score = 0;

    public void IncreaseScore()
    {
        Score += value;
        ScoreText.text = Score.ToString();
    }

    public void OnVegetableCut()
  {
    //IncreaseScore();
    Debug.Log("Cut");
    ScoreText.text = Score.ToString();
  }
}
