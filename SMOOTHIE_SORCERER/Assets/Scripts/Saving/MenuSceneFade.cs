using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneFade : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f;

    public Transform paperPanel;
    public Transform themePanel;
    public Transform levelPanel;
    public RectTransform menuContainer;

    public Text paperBuySetText;
    public Text themeBuySetText;
    public Text moneyText;

    private int [] paperCost = new int [] {0,20,30};
    private int [] themeCost = new int [] {100,110,110};
    private int selectedPaperIndex;
    private int selectedThemeIndex;
    private int activePaperIndex;
    private int activeThemeIndex;


    private Vector3 desiredMenuPosition;

    private void Start()
    {
        Debug.Log("in start method");
        //temp starting money
        SaveManager.Instance.state.Money = 999;
        ///current money
        UpdateMoneyText();
        
        //fadeGroup = FindObjectOfType<CanvasGroup>();

        //white on start
        fadeGroup.alpha = 1;

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
        
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;

        menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);
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

            i++;
        }
    }

    private void NavigateTo (int menuIndex)
    {
        switch  (menuIndex)
        {
            default:
            case 0:
                desiredMenuPosition = Vector3.zero;
                break;
            //1 = play menu
            case 1:
                desiredMenuPosition = Vector3.right * 1280;
                break;
            case 2:
                desiredMenuPosition = Vector3.left * 1280;
                break;
        }
    }

    private void SetPaper (int index)
    {
        //set active
        activePaperIndex = index;
        SaveManager.Instance.state.activePaper = index;
        //change room material

        //change buy set text
        paperBuySetText.text = "Current";
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
        themeBuySetText.text = "current";

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
    }
    public void OnBackClick()
    {
        NavigateTo(3);
    }
    public void OnShopClick ()
    {
        NavigateTo(2);
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
                paperBuySetText.text = "Current";
            }else 
            {
                paperBuySetText.text = "Select";
            }

            
        }
        else 
        {
            //not owned
             paperBuySetText.text = "Buy" + paperCost[currentIndex].ToString();
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
                themeBuySetText.text = "Current";
            }else 
            {
                themeBuySetText.text = "Select";
            }

        }
        else 
        {
            //not owned
             themeBuySetText.text = "Buy" + themeCost[currentIndex].ToString();
        }
    }
    private void OnLevelSelect(int currentIndex)
    {
        
        Debug.Log("select level button" + currentIndex);
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
}
