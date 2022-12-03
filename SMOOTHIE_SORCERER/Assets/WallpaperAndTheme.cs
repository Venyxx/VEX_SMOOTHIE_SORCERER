using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallpaperAndTheme : MonoBehaviour
{
    private GameObject RoomPrefab;
    private Material roomMaterial;

    private GameObject theme0;
    private GameObject theme1;
    private GameObject theme2;
    private GameObject theme3;
    public bool found;
    
    // Start is called before the first frame update
    void Start()
    {
        RoomPrefab = GameObject.Find("Smoothie_Room");
        DontDestroyOnLoad(gameObject);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveManager.Instance.state.activePaper == 0)
            ChangingMaterial("W_Chismas");
        else if (SaveManager.Instance.state.activePaper == 1)
            ChangingMaterial("W_Tropical");
        else if (SaveManager.Instance.state.activePaper == 2)
            ChangingMaterial("s1");//TEMP  
        else if (SaveManager.Instance.state.activePaper == 3)
            ChangingMaterial("W_Scurry");
        else if (SaveManager.Instance.state.activePaper == 4)
            ChangingMaterial("W_Tails_Of_Yarn");
        else if (SaveManager.Instance.state.activePaper == 5)
            ChangingMaterial("W_Melody_Knight");
        else if (SaveManager.Instance.state.activePaper == 6)
            ChangingMaterial("s2"); // temp
        else if (SaveManager.Instance.state.activePaper == 7)
            ChangingMaterial("s3");

        if (!found && SceneManager.GetActiveScene().name == "SampleScene")
        {
            FindThemes();
            found = true;
        }

        if (found && SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (SaveManager.Instance.state.activeTheme == 0)
                ChangingTheme("NormalTheme");
            else if (SaveManager.Instance.state.activeTheme == 1)
                ChangingTheme("ChristmasTheme");
            else if (SaveManager.Instance.state.activeTheme == 2)
                ChangingTheme("FantasyTheme");
            else if (SaveManager.Instance.state.activeTheme == 3)
                ChangingTheme("TropicalTheme");
        }

        
        if (!found && SceneManager.GetActiveScene().name == "Endless1")
        {
            FindThemes();
            found = true;
        }

        if (found && SceneManager.GetActiveScene().name == "Endless1")
        {
            if (SaveManager.Instance.state.activeTheme == 0)
                ChangingTheme("NormalTheme");
            else if (SaveManager.Instance.state.activeTheme == 1)
                ChangingTheme("ChristmasTheme");
            else if (SaveManager.Instance.state.activeTheme == 2)
                ChangingTheme("FantasyTheme");
            else if (SaveManager.Instance.state.activeTheme == 3)
                ChangingTheme("TropicalTheme");
        }
    }

    private void ChangingMaterial( string MaterialName )
    {
        if (!GameObject.Find("Smoothie_Room_Improved"))
        return;

        var room = GameObject.Find("Smoothie_Room_Improved");
        roomMaterial = Resources.Load<Material>(MaterialName);
        MeshRenderer mat = room.GetComponent<MeshRenderer>();      
        mat.material = roomMaterial;
    }

    private void ChangingTheme( string state)
    {
        if (state == "NormalTheme")
        {
            theme1.SetActive(false);
            theme2.SetActive(false);
            theme3.SetActive(false);
        } else if ( state == "ChristmasTheme")
        {
            theme0.SetActive(false);
            theme2.SetActive(false);
            theme3.SetActive(false);
        }else if ( state == "FantasyTheme")
        {
            theme0.SetActive(false);
            theme1.SetActive(false);
            theme3.SetActive(false);
        }else if ( state == "TropicalTheme")
        {
            theme0.SetActive(false);
            theme1.SetActive(false);
            theme2.SetActive(false);
        }
    }


    private void FindThemes ()
    {
        if (GameObject.Find("NormalTheme"))
            theme0 = GameObject.Find("NormalTheme");

        if (GameObject.Find("ChristmasTheme"))
            theme1 = GameObject.Find("ChristmasTheme");

        if (GameObject.Find("FantasyTheme"))
            theme2 = GameObject.Find("FantasyTheme");
        
        if (GameObject.Find("TropicalTheme"))
            theme3 = GameObject.Find("TropicalTheme");
    }
}
