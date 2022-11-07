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
   // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0)) 
    //    {
    //     RaycastHit hit; 
    //     Ray ray = cam.ScreenPointToRay(Input.mousePosition); 

    //     if (Physics.Raycast(ray, out hit, 10.0f)) 
    //    }

    // } 
    // Start is called before the first frame update
    public void Left ()
    {
        currentSmoothie.transform.position = plate1.position;
        currentSmoothie = null;
    }

    public void MidLeft()
    {
        currentSmoothie.transform.position = plate2.position;
        currentSmoothie = null;
    }

    public void MidRight()
    {
        currentSmoothie.transform.position = plate4.position;
        currentSmoothie = null;
    }

    public void Right()
    {
        currentSmoothie.transform.position = plate3.position;
        currentSmoothie = null;
    }
    
}
