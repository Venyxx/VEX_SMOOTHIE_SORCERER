using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    public bool isCustomer;
    private GameObject customer;
    public GameSystem gameSystem;
    
    
        [SerializeField]public bool hasBananaLEAVE;
        [SerializeField]public bool hasBlueberryLEAVE;
        [SerializeField]public bool hasStrawberryLEAVE;
        [SerializeField]public float SmoothieValueLEAVE;
        
    // Start is called before the first frame update
    void Start()
    {
        // canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        gameSystem = GameObject.Find("Game System").GetComponent<GameSystem>();
    }

    void OnTriggerEnter (Collider col)
    {
        GameObject other = col.gameObject;

        if (col.gameObject.tag == "Customer")
        {
            isCustomer = true;
            customer = col.gameObject;
            Debug.Log("customer woo");
        }

        if (col.gameObject.tag == "FinishedOrder" && isCustomer)
        { 
            

             if (col.gameObject.name == "BootCup(Clone)")
             {
                 Debug.Log("speed leave");
                customer.GetComponent<Moveable>().speedMetersPerSecond = 15.0f;
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

            gameSystem.value = col.GetComponent<FinishedSmoothie>().SmoothieValue;
            gameSystem.IncreaseScore(); //+= SmoothieValueLEAVE;
            Debug.Log("im giving them the shit");
            var Smoothie = col.gameObject;
           //customer.GetComponent<RailWaypointNav>().isLeaving = true;
            //customer.GetComponent<LeaveBehavior>();
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
