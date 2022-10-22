using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CauldronBlending : MonoBehaviour
{
    public List<GameObject> collidedObj;
        public bool hasBanana;
        public bool hasBlueberry;
        public bool hasStrawberry;
        
    // Start is called before the first frame update
    public void Start()
    {
        collidedObj = new List<GameObject>();  
    }

    public void Update()
    {
    
    }

    public void OnTriggerEnter (Collider col)
    {
         if (col.transform.tag == "Slice" && !collidedObj.Contains(col.gameObject))
         collidedObj.Add(col.gameObject);

         Debug.Log("Added");
        //  Debug.Log(collidedObj);

         if (col.gameObject.name == "Cube(Clone)")
          {
             hasBanana = true;
          }

          if (col.gameObject.name == "Strawberry_export(Clone)")
          {
            hasStrawberry = true;
          }

    }
}
