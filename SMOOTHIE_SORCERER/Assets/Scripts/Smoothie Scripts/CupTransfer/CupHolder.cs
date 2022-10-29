using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHolder : MonoBehaviour
{
        [Header("Fruits--------------")]
        public bool hasBananaCup;
        public bool hasBlueberryCup;
        public bool hasStrawberryCup;

        [Header("Effects---------------")]
        public bool hasSpeed;
        public bool hasInvis;
        public bool hasPoly;
        
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
       

         if (col.gameObject.name == "Banana(Clone)")
          {
             hasBananaCup = true;
             

          }

          if (col.gameObject.name == "Strawberry_export(Clone)")
          {
            hasStrawberryCup = true;
          }

          if (col.gameObject.name == "Blueberry(Clone)")
          {
            hasBlueberryCup = true;
          }

    }

    
}
