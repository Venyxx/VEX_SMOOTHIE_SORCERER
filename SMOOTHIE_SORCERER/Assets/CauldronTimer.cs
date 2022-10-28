using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CauldronTimer : MonoBehaviour
{
    public float currentTime;
    [SerializeField] public bool isBlending;
    public TextMeshProUGUI timerText;
    private Camera cam;
    private CauldronBlending caulblenREF;

    public float maxWellBlended;
    [SerializeField] public bool isFinished;


    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
        isBlending = false;
        isFinished = false;
        caulblenREF = gameObject.GetComponent<CauldronBlending>();
    }

    // Update is called once per frame
    void Update()
    {
   
        if (isBlending)
        {   
             currentTime += Time.deltaTime;  
        }

        if (Input.GetMouseButtonDown(0)) 
        {
        RaycastHit hit; 
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); 

        if (Physics.Raycast(ray, out hit, 10.0f)) 
        {
            if (hit.collider.tag == "Blender")
            {
                GameObject Cauldron = hit.collider.gameObject;
                Debug.Log("ON");
                
                
                if (!isBlending)
                {   
                      isBlending = true;
                }
                else if (isBlending)
                {
                    isBlending = false;
                    Debug.Log("sending value to smoothie");

                    //we will have to break it down for each second decr value later
                    //this is the send off, clear every cauldron value 
                    if (currentTime > maxWellBlended)
                    {
                        caulblenREF.CauldronValue =- 1;
                        isFinished = true;

                        //reset
                        currentTime = 0;
                        isFinished = false;
                        isBlending = false;
                    }
                    
                    //return value of current time
                }
                       
            }

        }
       
        }

    }
}
