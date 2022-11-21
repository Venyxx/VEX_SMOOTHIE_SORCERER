using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    public bool isCustomer;
    private GameObject customer;
    public GameSystem gameSystem;
    private CustomerOrder CustomerOrder;
    private FinishedSmoothie finishedScript;

    public AudioClip speedSound;
    public AudioClip invisSound;
    public AudioClip polySound;
    private AudioSource audioSource;
        
    // Start is called before the first frame update
    void Start()
    {
        gameSystem = GameObject.Find("Game System").GetComponent<GameSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter (Collider col)
    {
        GameObject other = col.gameObject;

        if (col.gameObject.tag == "Customer")
        {
            isCustomer = true;
            customer = col.gameObject;
            CustomerOrder = customer.GetComponent<CustomerOrder>();
            //Debug.Log("customer woo");
        }

        if (col.gameObject.tag == "FinishedOrder" && isCustomer)
        { 
            //finsmoothie ref
            finishedScript = col.gameObject.GetComponent<FinishedSmoothie>();
            //what to add to the score
            var ADDTHIS = col.gameObject.GetComponent<FinishedSmoothie>().SmoothieValue;
            //leave behavior
             if (col.gameObject.name == "BootCup(Clone)")
             {
                //Debug.Log("speed leave");
                customer.GetComponent<Moveable>().speedMetersPerSecond = 15.0f;
                customer.GetComponent<RailWaypointNav>().isLeaving = true;
                audioSource.PlayOneShot(speedSound, 0.7F);
                bool bootcup = true;
                if (bootcup != CustomerOrder.wantSpeed)
                {
                    ADDTHIS -= 1;
                }
   
             }else if (col.gameObject.name == "BarberCup(Clone)")
             {
                Debug.Log("invis leave");
                customer.GetComponent<RailWaypointNav>().isLeaving = true;
                audioSource.PlayOneShot(invisSound, 0.7F);
                bool invis = true;
                if (invis != CustomerOrder.wantInvis)
                {
                    ADDTHIS -= 1;
                }

             }else if (col.gameObject.name == "Coconut(Clone)")
             {
                Debug.Log("poly leave");
                customer.GetComponent<RailWaypointNav>().isLeaving = true;
                audioSource.PlayOneShot(polySound, 0.7F);
                bool poly = true;
                if (poly != CustomerOrder.wantPolymorph)
                {
                    ADDTHIS -= 1;
                }
             }

             
            // minus for wrong fruits
             if (CustomerOrder.wantBanana != finishedScript.hasBananaFIN)
             {
                ADDTHIS -= 1; 
             }
             if (CustomerOrder.wantStrawberry != finishedScript.hasStrawberryFIN)
             {
                ADDTHIS -= 1; 
             }
             if (CustomerOrder.wantBlueberry != finishedScript.hasBlueberryFIN)
             {
                ADDTHIS -= 1; 
             }

            //actually adding to the score
            gameSystem.IncreaseScore(ADDTHIS);
            
            
            //customer.GetComponent<RailWaypointNav>().isLeaving = true;
            //customer.GetComponent<LeaveBehavior>();
            Destroy(col.gameObject);

        } else if (col.gameObject.tag == "FinishedOrder" && !isCustomer)
        {
            Debug.Log("there is no one thee dummy");
        }
    }

    void OnTriggerExit (Collider col)
    {
        if (col.gameObject.tag == "Customer")
        {
            isCustomer = false;
            customer = null;
            Debug.Log("no more customer");
        }
    }

   private void CheckCustomerOrder (GameObject customer, string givenSmoothie)
   {
       // var storage = customer.GetComponent<CustomerOrder>();
        //if (storage.wantStrawberry && storage.wantBanana && givenSmoothie = "")
   }
}
