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

    // public void Update()
    // {
    //     if(collidedObj.Contains("Cube"))
    //     {
    //         Debug.Log("We Got Cubes");
    //     }
    // }

    public void OnTriggerEnter (Collider col)
    {
         if (col.transform.tag == "Slice" && !collidedObj.Contains(col.gameObject))
         collidedObj.Add(col.gameObject);

         Debug.Log("Added");
         Debug.Log(collidedObj);

    }
}
