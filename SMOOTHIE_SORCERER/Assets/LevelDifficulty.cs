using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour
{
    private GameObject GameSystem;
    public bool isSetAmount;
    // Start is called before the first frame update
    void Start()
    {
        isSetAmount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSetAmount && GameObject.Find("Game System"))
        {
            GameSystem = GameObject.Find("Game System");
            if (Manager.Instance.currentLevel == 0)
                GameSystem.GetComponent<GameCompletion>().MaxCustomers = 2;
            else if (Manager.Instance.currentLevel == 1)
                GameSystem.GetComponent<GameCompletion>().MaxCustomers = 6;
            else if (Manager.Instance.currentLevel == 2)
                GameSystem.GetComponent<GameCompletion>().MaxCustomers = 10;
            
            
            isSetAmount = true;
        }
        
    }
}
