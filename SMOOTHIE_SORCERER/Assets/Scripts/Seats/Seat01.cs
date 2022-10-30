using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat01 : MonoBehaviour
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
            SeatChecker.seatBools[1] = true;
            Debug.Log("there is someone in seat 01");
            SeatItself.hasCustomer = true;
        }
        
    }

    private void OnTriggerExit (Collider collision)
    {
        SeatChecker.seatBools[1] = false;
        Debug.Log("there is no one in seat 01");
        SeatItself.hasCustomer = false;
    }

    
}
