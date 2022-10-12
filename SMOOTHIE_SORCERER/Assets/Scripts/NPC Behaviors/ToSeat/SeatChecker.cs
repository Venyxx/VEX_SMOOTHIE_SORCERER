using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SeatChecker : MonoBehaviour
{
    public List<Transform> seats;
    public GameObject seatHolder;
    public bool seat1;
    public bool seat2;
    public bool seat3;
    public bool seat4;

    // Start is called before the first frame update
    void Start()
    {
        seats = seatHolder.GetComponentsInChildren<Transform>().ToList(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        for (int i = 0; i < 4; i++)
        {
        
        }
    }
}
