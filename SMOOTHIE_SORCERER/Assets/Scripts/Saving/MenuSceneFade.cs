using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneFade : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f;

    public Transform paperPanel;
    public Transform themePanel;
    public Transform levelPanel;
    public RectTransform menuContainer;

    public Text paperBuySetText;
    public Text themeBuySetText;

    private int [] paperCost = new int [] {0,20,30};
    private int [] themeCost = new int [] {100,110,110};
    private int selectedPaperIndex;
    private int selectedThemeIndex;

    private Vector3 desiredMenuPosition;

    private void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>();

        //white on start
        fadeGroup.alpha = 1;

        // button on click events to shop 
        InitShop();

        //Add buttons on click to levels
        InitLevel();
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

            i++;
        }
        i = 0;

        foreach (Transform t in themePanel)
        {
            int currentIndex = i;
            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnThemeSelect(currentIndex));

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
            b.onClick.AddListener(() => OnLevelSelect(currentIndex));

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
        //change room material

        //change buy set text
        paperBuySetText.text = "current";
    }

    private void SetTheme (int index)
    {
        //change theme material

        //change buy set text
        themeBuySetText.text = "current";
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
        Debug.Log("select paper button" + currentIndex);
        //set selected paper
        selectedPaperIndex = currentIndex;

        // change content od buy set button
        if (SaveManager.Instance.IsPaperOwned(currentIndex))
        {
            //owned wallpaper color
            paperBuySetText.text = "Select";
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
        
        //set selected theme
        selectedThemeIndex = currentIndex;

        // change content od buy set button
        if (SaveManager.Instance.IsThemeOwned(currentIndex))
        {
            //owned wallpaper color
            themeBuySetText.text = "Select";
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

            }else
            {
                Debug.Log("youre broke");
            }

        }
    }
}
