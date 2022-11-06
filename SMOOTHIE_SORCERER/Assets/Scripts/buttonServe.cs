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
    // Start is called before the first frame update
    public void Left ()
    {
        currentSmoothie.transform.position = plate1.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
