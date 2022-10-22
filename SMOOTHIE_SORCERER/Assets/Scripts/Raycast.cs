using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera cam;
    private RailWaypointNav customerNavREF;
    private CustomerOrder customerOrderREF;
    private Ticket ticketREF;

    private GameObject ticket;
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
                GameObject customer = hit.collider.gameObject;

                customerOrderREF = customer.GetComponent<CustomerOrder>();
                customerNavREF = customer.GetComponent<RailWaypointNav>();
                customerNavREF.clickedStartingOrder = true;
                Debug.Log("raycast found the customer");

                //set the ticket
                ticket = GameObject.Find("CurrentOrderTicket");
                ticketREF = ticket.GetComponent<Ticket>();

                ticketREF.orderBanana = customerOrderREF.wantBanana;
                ticketREF.orderStrawberry = customerOrderREF.wantStrawberry;
                ticketREF.orderBlueberry = customerOrderREF.wantBlueberry;

                
            }
        }
       }
    }
}
