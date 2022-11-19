using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameCompletion : MonoBehaviour
{
    [SerializeField] public int MaxCustomers;
    [SerializeField] public int CurrentCustomers;
    [SerializeField] public TextMeshProUGUI earnings;


    public GameObject endMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        endMenuUI.SetActive(false);
        CurrentCustomers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentCustomers == MaxCustomers)
        {
            
            Invoke("LevelCompletion", 3f);
        }
    }

    void LevelCompletion ()
    {
        //save and add to completable levels
        SaveManager.Instance.CompleteLevel(Manager.Instance.currentLevel);

        //focus level selection on return
        Manager.Instance.menuFocus = 1;

        //ExitScene();
        Time.timeScale = 0f;
        if (endMenuUI)
        {
            endMenuUI.SetActive(true);
        }
        
        var localScore = gameObject.GetComponent<GameSystem>().Score;
        
        earnings.text  =("$ " + localScore.ToString());

        

    }

    public void ExitScene ()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void NextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
