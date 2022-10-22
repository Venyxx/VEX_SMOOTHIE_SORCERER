using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordering : MonoBehaviour
{
    private RailWaypointNav navREF;
    public GameObject OrderingSprite;
    public GameObject IrritantContainer;

    // Start is called before the first frame update
    void Start()
    {
        navREF = GetComponent<RailWaypointNav>();
        OrderingSprite.SetActive(false);
        IrritantContainer.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (navREF.clickedStartingOrder == true)
        {
            OrderingSprite.SetActive(true);
            IrritantContainer.SetActive(true);
            //Debug.Log("we are ordering now");
        }
    }

    private void orderDisplay ()
    {
        
    }
}
