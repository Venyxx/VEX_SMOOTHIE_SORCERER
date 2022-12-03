using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class MenuSceneFade : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.66f;
    public CinemachineVirtualCamera frontCamera;
    public CinemachineVirtualCamera backCamera;
    public CinemachineVirtualCamera shopCamera;
    public CinemachineVirtualCamera skyCamera;


    public Transform paperPanel;
    public Transform themePanel;
    public Transform levelPanel;
    public Transform creditsPanel;
    public RectTransform menuContainer;

    public Text paperBuySetText;
    public Text themeBuySetText;
    public Text moneyText;
    public TextMeshProUGUI highscoreText;

    public AudioClip clip;
    public AudioClip close;
    AudioSource audioSource;

    private int [] paperCost = new int [] {0,15,20,25,30,50,55,60,65};
    private int [] themeCost = new int [] {0,50,55,60};
    private int selectedPaperIndex;
    private int selectedThemeIndex;
    private int activePaperIndex;
    private int activeThemeIndex;


    private Vector3 desiredMenuPosition;
    public GameObject helpScreen;

    private void Start()
    {
        GameObject.Find("Manager").GetComponent<LevelDifficulty>().isSetAmount = false;
        GameObject.Find("Manager").GetComponent<LevelDifficulty>().isEndless = false;
        GameObject.Find("Manager").GetComponent<WallpaperAndTheme>().found = false;

        SetHighScoreText();
        
        audioSource = GetComponent<AudioSource>();
        helpScreen = GameObject.Find("HelpScreenPNG");
        helpScreen.SetActive(false);
        Time.timeScale = 1f;
        frontCamera.gameObject.SetActive(true);
        backCamera.gameObject.SetActive(false);
        shopCamera.gameObject.SetActive(false);
        skyCamera.gameObject.SetActive(false);
        
        //temp starting money
        

        //pos camera on focus menu 
        SetCameraTo(Manager.Instance.menuFocus);
        ///current money
        UpdateMoneyText();
        
        //fadeGroup = GameObject.Find("Fade").GetComponent<CanvasGroup>();

        //white on start
        //fadeGroup.alpha = 1;

        // button on click events to shop 
        InitShop();

        //Add buttons on click to levels
        InitLevel();

        //player pref
        OnPaperSelect(SaveManager.Instance.state.activePaper);
        SetPaper(SaveManager.Instance.state.activePaper);
        

        OnThemeSelect(SaveManager.Instance.state.activeTheme);
        SetTheme(SaveManager.Instance.state.activeTheme);

        //visual selected item
        paperPanel.GetChild(SaveManager.Instance.state.activePaper).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;
        themePanel.GetChild(SaveManager.Instance.state.activeTheme).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;
    } 

    private void Update ()
    {
        //Debug.Log(fadeGroup.alpha);
        //fadeGroup.alpha = 1 - (Time.timeSinceLevelLoad + 0.1f) * fadeInSpeed;

        

        if (skyCamera.gameObject.activeInHierarchy == true)
        {
            menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.05f);
        } else 
        {
            menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);
        }
        
    }

    private void InitShop ()
    {
        //make sure there are refs
        if (paperPanel == null || themePanel == null)
        {
            Debug.Log("not assigned");
        }

        // for each child button find buton and add 
        int i = 0;
        foreach (Transform t in paperPanel)
        {
            int currentIndex = i;
            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnPaperSelect(currentIndex));

            //set color if owned
            Image img = t.GetComponent<Image>();
            img.color = SaveManager.Instance.IsPaperOwned(i) ? Color.white : new Color (0.7f, 0.7f, 0.7f);

            i++;
        }
        i = 0;

        foreach (Transform t in themePanel)
        {
            int currentIndex = i;
            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnThemeSelect(currentIndex));

            //set theme if owned
            Image img = t.GetComponent<Image>();
            img.color = SaveManager.Instance.IsThemeOwned(i) ? Color.white : new Color (0.7f, 0.7f, 0.7f);

            i++;
        }

    }

    private void InitLevel()
    {
        //make sure there are refs
        if (levelPanel == null)
        {
            Debug.Log("not assigned");
        }

        // for each child button find buton and add 
        int i = 0;
        foreach (Transform t in levelPanel)
        {
            int currentIndex = i;
            Button b = t.GetComponent<Button>();
            //b.onClick.AddListener(() => OnLevelSelect(currentIndex));

            Image img = t.GetComponent<Image>();
            if (i <= SaveManager.Instance.state.completedLevel)
            {
                //its unlocked fr
                if (i == SaveManager.Instance.state.completedLevel)
                {
                    img.color = Color.white;
                    //in progress
                }
                else 
                {
                    //level is completed
                    img.color = Color.green;
                }
            } else
            {
                //not completed or unlocked
                b.interactable = false;
                img.color = Color.grey;
            }

            //is it unlocked

            i++;
        }
    }

    private void SetCameraTo (int menuIndex)
    {
        NavigateTo(menuIndex);
        menuContainer.anchoredPosition3D = desiredMenuPosition;
    }

    private void NavigateTo (int menuIndex)
    {
        switch  (menuIndex)
        {
            default:
            case 0:
                desiredMenuPosition = Vector3.zero;
                break;
            case 1:
                desiredMenuPosition = Vector3.right * 1280;
                break;    
            case 2:
                desiredMenuPosition = Vector3.left * 1280;
                break;
            case 3: 
                desiredMenuPosition = Vector3.down * 720;
                break;

                //1 is play, 2 shop, 3 credits , 4 back? idk how 
        }
    }

    private void SetPaper (int index)
    {
        //set active
        activePaperIndex = index;
        SaveManager.Instance.state.activePaper = index;

        
        //change room material


        //change buy set text
        paperBuySetText.text = "Current Wallpaper!";
         Debug.Log("ran set paper");

        SaveManager.Instance.Save();
    }

    private void SetTheme (int index)
    {
        //set active
        activeThemeIndex = index;
        SaveManager.Instance.state.activeTheme = index;
        //change theme material

        //change buy set text
        themeBuySetText.text = "Current Theme!";

         SaveManager.Instance.Save();
    }

    private void UpdateMoneyText ()
    {
        moneyText.text = SaveManager.Instance.state.Money.ToString();
    }

    //buttons
    public void OnPlayClick ()
    {
        NavigateTo(1);
        backCamera.gameObject.SetActive(true);
    }
    public void OnShopClick ()
    {
        NavigateTo(2);
        shopCamera.gameObject.SetActive(true);
    }
    public void OnBackClick()
    {
        backCamera.gameObject.SetActive(false);
        shopCamera.gameObject.SetActive(false);
        skyCamera.gameObject.SetActive(false);
        NavigateTo(4);
    }
    public void OnCreditsClick ()
    {
        skyCamera.gameObject.SetActive(true);
        NavigateTo(3);
    }

    private void OnPaperSelect(int currentIndex)
    {
        //if clicked is alr active
        if (selectedPaperIndex == currentIndex)
        {
            Debug.Log("it was the current one");
            return;
           
        }

        //if not make the icon bigger
        paperPanel.GetChild(currentIndex).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;

        //make the old one normal sized
        paperPanel.GetChild(selectedPaperIndex).GetComponent<RectTransform>().localScale = Vector3.one;

        Debug.Log("select paper button" + currentIndex);
        //set selected paper
        selectedPaperIndex = currentIndex;

        // change content od buy set button
        if (SaveManager.Instance.IsPaperOwned(currentIndex))
        {
            //owned wallpaper color
            //is it alr current?
            if (activePaperIndex == currentIndex)
            {
                paperBuySetText.text = "Current Wallpaper!";
            }else 
            {
                paperBuySetText.text = "Select";
            }

            
        }
        else 
        {
            //not owned
             paperBuySetText.text = "Buy " + paperCost[currentIndex].ToString();
        }

    }
    private void OnThemeSelect(int currentIndex)
    {
        Debug.Log("select theme button" + currentIndex);
        //if clicked is alr active
        if (selectedThemeIndex == currentIndex)
        {
            return;
        }


         //if not make the icon bigger
        themePanel.GetChild(currentIndex).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;

        //make the old one normal sized
        themePanel.GetChild(selectedThemeIndex).GetComponent<RectTransform>().localScale = Vector3.one;

        //set selected theme
        selectedThemeIndex = currentIndex;

        // change content od buy set button
        if (SaveManager.Instance.IsThemeOwned(currentIndex))
        {
            //owned wallpaper color
             //is it alr current?
            if (activeThemeIndex == currentIndex)
            {
                themeBuySetText.text = "Current Theme!";
            }else 
            {
                themeBuySetText.text = "Select";
            }

        }
        else 
        {
            //not owned
             themeBuySetText.text = "Buy " + themeCost[currentIndex].ToString();
        }
    }

    private void OnLevelSelect(int currentIndex)
    {
        Manager.Instance.currentLevel = currentIndex;
        SceneManager.LoadScene("SampleScene");
        Debug.Log("select level button: " + currentIndex);
    }

    

    public void OnPaperBuySet ()
    {
        Debug.Log("buy or set paper");
        //is it owned
        if (SaveManager.Instance.IsPaperOwned(selectedPaperIndex))
        {
            //set color
            SetPaper(selectedPaperIndex);
        }
        else
        {
            //attempt to buy
            if (SaveManager.Instance.BuyPaper(selectedPaperIndex, paperCost[selectedPaperIndex]))
            {
                //success
                SetPaper(selectedPaperIndex);
                //change color button
                paperPanel.GetChild(selectedPaperIndex).GetComponent<Image>().color = Color.white;

                //update visual money text
                UpdateMoneyText();
            }else
            {
                Debug.Log("youre broke");
                
            }

        }
    }
    public void OnThemeBuySet ()
    {
        Debug.Log("buy or set theme");
        
        //is it owned
        if (SaveManager.Instance.IsThemeOwned(selectedThemeIndex))
        {
            //set color theme
            SetTheme(selectedThemeIndex);
        }
        else
        {
            //attempt to buy
            if (SaveManager.Instance.BuyTheme(selectedThemeIndex, themeCost[selectedThemeIndex]))
            {
                //success
                SetTheme(selectedThemeIndex);

                //change color button
                themePanel.GetChild(selectedThemeIndex).GetComponent<Image>().color = Color.white;

                //update visual money text
                UpdateMoneyText();

            }else
            {
                Debug.Log("youre broke");
            }

        }
    }

      public void HelpMenuOpen ()
    {
        helpScreen.SetActive(true);
        audioSource.PlayOneShot(clip, 0.7F);
    }
     public void HelpMenuClose ()
    {
        helpScreen.SetActive(false);
        audioSource.PlayOneShot(close, 0.7F);
    }

    public void ResetThatSave()
    {
        SaveManager.Instance.ResetSave();
        Application.Quit();
        Debug.Log("im trying to wipe");
    }

    public void GoToEndless ()
    {
        SceneManager.LoadScene("Endless1");
    }

    public void SetHighScoreText ()
    {
        highscoreText.text = "$" + SaveManager.Instance.state.endlessHighScore;
    }

  
}
