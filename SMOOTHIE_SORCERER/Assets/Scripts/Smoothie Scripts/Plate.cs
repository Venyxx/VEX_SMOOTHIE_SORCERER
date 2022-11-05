using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private bool isCustomer;
    private GameObject customer;

    
        [SerializeField]public bool hasBananaLEAVE;
        [SerializeField]public bool hasBlueberryLEAVE;
        [SerializeField]public bool hasStrawberryLEAVE;
        [SerializeField]public float SmoothieValueLEAVE;
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
            Debug.Log("customer woo");
        }

        if (col.gameObject.tag == "FinishedOrder" && isCustomer)
        { 
            //SmoothieValueLEAVE = col.GetComponent<FinishedSmoothie>().SmoothieValueFIN;

            if (col.gameObject.name == "BootCup(Clone)")
            {
                Debug.Log("speed leave");
                customer.GetComponent<RailWaypointNav>().isLeaving = true;
                
            } else if (col.gameObject.name == "BarberCup(Clone)")
            {
                Debug.Log("invis leave");
                customer.GetComponent<RailWaypointNav>().isLeaving = true;
            }
            else if (col.gameObject.name == "Coconut(Clone)")
            {
                Debug.Log("poly leave");
                customer.GetComponent<RailWaypointNav>().isLeaving = true;
            }

            
            Debug.Log("im giving them the shit");
            var Smoothie = col.gameObject;
            customer.GetComponent<LeaveBehavior>();

            Destroy(col.gameObject);

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

   private void CheckCustomerOrder (GameObject customer, string givenSmoothie)
   {
       // var storage = customer.GetComponent<CustomerOrder>();
        //if (storage.wantStrawberry && storage.wantBanana && givenSmoothie = "")
   }
}
