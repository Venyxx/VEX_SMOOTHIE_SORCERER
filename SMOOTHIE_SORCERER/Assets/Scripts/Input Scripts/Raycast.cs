using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public Camera cam;
    public TMP_Text currentorder;
    private RailWaypointNav customerNavREF;
    private CustomerOrder customerOrderREF;
    //private Ticket ticketREF;

    private GameObject ticket;
    public GameObject CupObj;
    public GameObject CupSpawn;
    private Vector3 cupVector;

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
                currentorder.text = "This customer wants Strawberry";
                //ticketREF = ticket.GetComponent<Ticket>();

               // ticketREF.orderBanana = customerOrderREF.wantBanana;
                //ticketREF.orderStrawberry = customerOrderREF.wantStrawberry;
                //ticketREF.orderBlueberry = customerOrderREF.wantBlueberry;

                
            }

            if (hit.collider.tag == "CupStack")
            {
                cupVector.x = CupSpawn.transform.position.x; 
                cupVector.y = CupSpawn.transform.position.y;
                cupVector.z =  CupSpawn.transform.position.z;
                Debug.Log("got cupstack");
                Instantiate(CupObj, cupVector, Quaternion.identity);
            }
        }
       }
    }
}
