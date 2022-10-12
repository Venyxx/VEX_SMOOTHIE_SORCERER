using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatItself : MonoBehaviour
{
    private SeatChecker SeatChecker;
    // Start is called before the first frame update
    void Start()
    {
      
      GameObject seatManager = GameObject.FindGameObjectWithTag("SeatingManager");
        SeatChecker = seatManager.GetComponent<SeatChecker>(); 
        SeatChecker.seat1 = false; 
    }

    private void OnTriggerEnter (Collider collision)
    {
        if (collision.tag == "Customer")
        {
            SeatChecker.seat1 = true;
            Debug.Log("there is someone in seat 1");
        }
        
    }

    private void OnTriggerExit (Collider collision)
    {
        SeatChecker.seat1 = false;
        Debug.Log("there is no one in seat 1");
    }

    
}
