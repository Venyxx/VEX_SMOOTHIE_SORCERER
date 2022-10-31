using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordering : MonoBehaviour
{
    private RailWaypointNav navREF;
    
    public GameObject IrritantContainer;

    // Start is called before the first frame update
    void Start()
    {
        navREF = GetComponent<RailWaypointNav>();
        
        IrritantContainer.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (navREF.canOrder)
        {
            IrritantContainer.SetActive(true);
        }

    }

    private void orderDisplay ()
    {
        
    }
}
