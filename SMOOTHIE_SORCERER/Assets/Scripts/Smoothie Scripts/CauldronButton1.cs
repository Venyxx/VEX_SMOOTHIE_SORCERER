using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CauldronButton1 : MonoBehaviour
{
    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    public Camera cam;
    public GameObject Canvas;

    private Timer _timerScript;

   
 
     // Use this for initialization
     void Start () 
     {
         definedButton = this.gameObject;
         _timerScript = Canvas.GetComponent<Timer>();
         
         
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

                Debug.Log("Button Clicked");
                 OnClick.Invoke();
                       
            }

        }
       
        }

    }
}



