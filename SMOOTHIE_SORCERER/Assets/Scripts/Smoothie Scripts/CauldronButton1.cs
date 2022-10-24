using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CauldronButton1 : MonoBehaviour
{
    public GameObject definedButton;
     public UnityEvent OnClick = new UnityEvent();
     public Camera cam;

     private bool checkCauldronOn;
     private CauldronBlending cauld;


     public GameObject orderTixComparison;
     private Ticket orderTicket;
     
     public GameObject GameSystem;
    private GameSystem gSys;

    // this is just hard coded for now tbh. well make it recognize its own real tix later -v
 
     // Use this for initialization
     void Start () 
     {
         definedButton = this.gameObject;
         checkCauldronOn = false;
         //GameSystem = GameObject.Find("GameSystem");

         gSys = GameSystem.GetComponent<GameSystem>();

           
     }
     
     // Update is called once per frame
     void Update () 
     {
        if (Input.GetMouseButtonDown(0)) 
       {
        RaycastHit hit; 
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); 

        if (Physics.Raycast(ray, out hit, 10.0f)) 
        {
            if (hit.collider.tag == "Blender")
            {
                GameObject Cauldron = hit.collider.gameObject;
                
                cauld = GetComponent<CauldronBlending>();
                orderTicket = orderTixComparison.GetComponent<Ticket>();

                if (cauld.hasBanana != orderTicket.orderBanana)
                {
                    Debug.Log("oh no");
                    gSys.Score -= 1;
                }
                if (cauld.hasStrawberry != orderTicket.orderStrawberry)
                {
                    gSys.Score -= 1;
                }
                if (cauld.hasBlueberry != orderTicket.orderBlueberry)
                {
                    gSys.Score -= 1;
                }

                Debug.Log("Button Clicked");
                 OnClick.Invoke();
            }     

        }
 
       }

    
     }
}

