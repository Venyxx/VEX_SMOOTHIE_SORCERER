using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatItself : MonoBehaviour
{
    private SeatChecker SeatChecker;
    
    [SerializeField] public bool hasCustomer;
    // Start is called before the first frame update
    void Start()
    {
      
        GameObject seatManager = GameObject.FindGameObjectWithTag("SeatingManager");
        SeatChecker = seatManager.GetComponent<SeatChecker>(); 
 
    }

}
