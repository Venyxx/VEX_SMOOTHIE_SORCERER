using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDifficulty : MonoBehaviour
{
    private GameObject GameSystem;
    public bool isSetAmount;
    public bool isEndless;
    // Start is called before the first frame update
    void Start()
    {
        isSetAmount = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Endless1")
        {
            isEndless = true;
        }

        if (!isSetAmount && GameObject.Find("Game System"))
        {
            GameSystem = GameObject.Find("Game System");

            if (!isEndless)
            {
                if (Manager.Instance.currentLevel == 0)
                {
                    GameSystem.GetComponent<GameCompletion>().MaxCustomers = 2;
                    var customers = GameObject.Find("Phase2");
                    Destroy(customers);
                }
                    
                else if (Manager.Instance.currentLevel == 1)
                {
                    GameSystem.GetComponent<GameCompletion>().MaxCustomers = 6;
                    var customers = GameObject.Find("Phase3");
                    Destroy(customers);
                }
                else if (Manager.Instance.currentLevel == 2)
                    GameSystem.GetComponent<GameCompletion>().MaxCustomers = 16;


            } else
                GameSystem.GetComponent<GameCompletion>().MaxCustomers = 1000;

            isSetAmount = true;

        }
        
    }
}
