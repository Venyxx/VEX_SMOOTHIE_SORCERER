using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonServe : MonoBehaviour
{
   public GameObject currentSmoothie;
   public Transform plate1; 
   public Transform plate2;
   public Transform plate3;
   public Transform plate4;


   void Start ()
   {

   }
  
    public void Left ()
    {
         Debug.Log("hit button left check");
        currentSmoothie.transform.position = plate1.position;
        currentSmoothie = null;
        GameObject.Find("buttons").SetActive(false);
    }

    public void MidLeft()
    {
        currentSmoothie.transform.position = plate2.position;
        currentSmoothie = null;
        GameObject.Find("buttons").SetActive(false);
    }

    public void MidRight()
    {
        currentSmoothie.transform.position = plate4.position;
        currentSmoothie = null;
        GameObject.Find("buttons").SetActive(false);
    }

    public void Right()
    {
        currentSmoothie.transform.position = plate3.position;
        currentSmoothie = null;
        GameObject.Find("buttons").SetActive(false);
    }
    
}
