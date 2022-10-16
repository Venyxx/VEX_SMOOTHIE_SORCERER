using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordering : MonoBehaviour
{
    public RailWaypointNav navREF;
    public GameObject sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (navREF.canOrder == true)
        {
            sprite.SetActive(true);
            //Debug.Log("we are ordering now");
        }
    }

    private void orderDisplay ()
    {
        
    }
}
