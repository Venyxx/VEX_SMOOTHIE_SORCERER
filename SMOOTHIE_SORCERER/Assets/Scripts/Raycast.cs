using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera cam;
    private RailWaypointNav customerNavREF;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
       if (Input.GetMouseButtonDown(0)) 
       {
        RaycastHit hit; 
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); 

        if (Physics.Raycast(ray, out hit, 10.0f)) 
        {
            if (hit.collider.tag == "Customer")
            {
                Debug.Log("raycast found the customer");
                GameObject customer = hit.collider.gameObject;

                 customerNavREF = customer.GetComponent<RailWaypointNav>();
                customerNavREF.clickedStartingOrder = true;
            }
        }
       }
    }
}
