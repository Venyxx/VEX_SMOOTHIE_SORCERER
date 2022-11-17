using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoader : MonoBehaviour
{
   private CanvasGroup fadeGroup;
   private float loadTime;
   private float minimumLogoTime = 3.0f;

   private void Start ()
   {
        fadeGroup = FindObjectOfType<CanvasGroup>();

        //white on start
        fadeGroup.alpha = 1;

        //pre load game
        //$$

        //get timestamp of completion time
        //if too fast, buffer time for logo
        if (Time.time < minimumLogoTime)
        {
            loadTime = minimumLogoTime;
        }else 
        {
            loadTime = Time.time;
        }

   }

   private void Update ()
   {
    // fade in
        if (Time.time < minimumLogoTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }
    // fade out
        if (Time.time > minimumLogoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minimumLogoTime;
            if ( fadeGroup.alpha >= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
   }
}
