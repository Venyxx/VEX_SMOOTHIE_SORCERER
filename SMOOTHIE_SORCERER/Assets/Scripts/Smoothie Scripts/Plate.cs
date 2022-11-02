using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private bool isCustomer;
    private GameObject customer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Customer")
        {
            isCustomer = true;
            customer = col.gameObject;
        }

        if (col.gameObject.tag == "FinishedOrder" && isCustomer)
        {
            Debug.Log("im giving them the shit");
        } else if (col.gameObject.tag == "FinishedOrder" && !isCustomer)
        {
            Debug.Log("there is no one thee dummy");
        }
    }

    void OnTriggerExit (Collider col)
    {
        if (col.gameObject.tag == "Customer")
        {
            isCustomer = false;
            customer = null;
            Debug.Log("no more customer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
