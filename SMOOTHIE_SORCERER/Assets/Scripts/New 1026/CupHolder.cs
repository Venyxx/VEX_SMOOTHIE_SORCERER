using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHolder : MonoBehaviour
{
        public bool hasBananaCup;
        public bool hasBlueberryCup;
        public bool hasStrawberryCup;
        
        [SerializeField] public float Value; 
    
    // Start is called before the first frame update
    void Start()
    {
        Value = 6.0f;
         bool hasBananaCup = false;
         bool hasBlueberryCup = false;
         bool hasStrawberryCup = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter (Collider col)
    {
       Debug.Log("were hitting the trigger");

         if (col.gameObject.name == "Cube(Clone)")
          {
             hasBananaCup = true;
             Debug.Log("were hitting the banana");

          }

          if (col.gameObject.name == "Strawberry_export(Clone)")
          {
            hasStrawberryCup = true;
          }

    }

    
}
