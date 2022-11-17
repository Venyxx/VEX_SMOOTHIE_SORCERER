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
        throw new NotImplementedException();
        Debug.Log("select paper button" + currentIndex);
    }
    
    private void OnThemeSelect(int currentIndex)
    {
        throw new NotImplementedException();
        Debug.Log("select theme button" + currentIndex);
    }
    private void OnLevelSelect(int currentIndex)
    {
        
        Debug.Log("select level button" + currentIndex);
    }

    

    public void OnPaperBuySet ()
    {
        Debug.Log("buy or set paper");
    }
    public void OnThemeBuySet ()
    {
        Debug.Log("buy or set theme");
    }
}
