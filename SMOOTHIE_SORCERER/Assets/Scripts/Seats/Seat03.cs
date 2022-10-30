using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat03 : MonoBehaviour
{
    private SeatChecker SeatChecker;
    private SeatItself SeatItself;
    //[SerializeField] public bool hasCustomer;
    // Start is called before the first frame update
    void Start()
    {
      
        GameObject seatManager = GameObject.FindGameObjectWithTag("SeatingManager");
        SeatChecker = seatManager.GetComponent<SeatChecker>(); 
        SeatItself = gameObject.GetComponent<SeatItself>();
        
    }

    private void OnTriggerEnter (Collider collision)
    {
        if (collision.tag == "Customer")
        {
            SeatChecker.seatBools[3] = true;
            Debug.Log("there is someone in seat 03");
             SeatItself.hasCustomer = true;
        }
        
    }

    private void OnTriggerExit (Collider collision)
    {
        SeatChecker.seatBools[3] = false;
        Debug.Log("there is no one in seat 03");
         SeatItself.hasCustomer = false;
    }

    
}
