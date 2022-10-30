using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat00 : MonoBehaviour
{
    private SeatChecker SeatChecker;
    //[SerializeField] public bool hasCustomer;
    private SeatItself SeatItself;
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
            SeatChecker.seatBools[0] = true;
            Debug.Log("there is someone in seat 00");
            SeatItself.hasCustomer = true;
        }
        
    }

    private void OnTriggerExit (Collider collision)
    {
        SeatChecker.seatBools[0] = false;
        Debug.Log("there is no one in seat 00");
        SeatItself.hasCustomer = false;
    }

    
}
