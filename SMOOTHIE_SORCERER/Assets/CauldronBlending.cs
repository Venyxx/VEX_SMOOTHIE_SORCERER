using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CauldronBlending : MonoBehaviour
{
    List<GameObject> collidedObj;
    
    // Start is called before the first frame update
    public void Start()
    {
        collidedObj = new List<GameObject>();
    }

    //public void Update()
    //{
    //    if(GameObject.Contains("Cube"))
    //    {
    //        Debug.Log("We Got Cubes");
    //    }
    //}

    public void OnTriggerEnter (Collider col)
    {
         if (col.transform.tag == "Slice" && !collidedObj.Contains(col.gameObject))
         collidedObj.Add(col.gameObject);

         Debug.Log("Added");

    }
}
