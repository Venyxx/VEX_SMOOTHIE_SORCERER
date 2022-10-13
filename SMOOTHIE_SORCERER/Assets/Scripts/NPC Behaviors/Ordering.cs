using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordering : MonoBehaviour
{
    public RailWaypointNav navREF;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (navREF.canOrder == true)
        {
            Debug.Log("we are ordering now");
        }
    }

    private void orderDisplay ()
    {
        
    }
}
