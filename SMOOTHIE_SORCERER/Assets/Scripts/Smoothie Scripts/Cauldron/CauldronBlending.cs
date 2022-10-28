using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class CauldronBlending : MonoBehaviour
{
    
        public bool hasBananaCaul;
        public bool hasBlueberryCaul;
        public bool hasStrawberryCaul;
        public bool wellBlended;
        public bool overBlended;
        
        public GameObject StrBanana;
        public GameObject BananaSM;
        public GameObject StrawbSM;
        public GameObject mistake;
        private Camera cam;

        [SerializeField] public float CauldronValue;
        private GameObject Cup;
        private GameObject beerTap;
        private CupHolder cupREF;
        private Transform cupMotive;
        public Transform smoothieSpawn;
        private CauldronTimer caulTimREF;
        private Vector3 smoothieSPA;
        
        public float currentTime;
        [SerializeField] public bool isBlending;
        public TextMeshProUGUI timerText;
        public float maxWellBlended;
        [SerializeField] public bool isFinished;
     

    // Start is called before the first frame update
    public void Start()
    {
        cam = Camera.main;
        wellBlended = false;
        isBlending = false;
        overBlended = false;
        
        caulTimREF = gameObject.GetComponent<CauldronTimer>();
        cupMotive = gameObject.transform.Find("CupMove");
        //beerTap = GameObject.Find("PotionTap");
        //smoothieSpawn = beerTap.transform.Find("SmoothieSpawn");
        
    }

    public void Update()
    {
        timerText.text = currentTime.ToString("0");

        if (isFinished)
        {
            //here is where we instantiate the smoothie and attach the values;
            SmoothiePicker();
            isFinished = false;
        }
        
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
                Debug.Log(hit.collider.tag);
                //get values from previous step
                if (hit.collider.tag == "Blender" && isBlending == false)
                {
                    Debug.Log("tagged it");
                    Cup = GameObject.FindGameObjectWithTag("Cup");
                    cupREF = Cup.GetComponent<CupHolder>();

                    hasBananaCaul = cupREF.hasBananaCup;
                    hasStrawberryCaul = cupREF.hasStrawberryCup;
                    hasBlueberryCaul = cupREF.hasBlueberryCup;

                    CauldronValue = cupREF.Value;

                    Cup.transform.position = cupMotive.transform.position;
                    Invoke ("CupKiller", 2f);

                    isBlending = true;

                }else if (hit.collider.tag == "Blender" && isBlending == true)
                {
                    //timer

                    isBlending = false;
                    Debug.Log("sending value to smoothie");

                    //we will have to break it down for each second decr value later
                    //this is the send off, clear every cauldron value 
                    if (currentTime > maxWellBlended)
                    {
                        CauldronValue =- 1;
                        isFinished = true;

                        //reset
                        currentTime = 0;
                        isBlending = false;
                    }
                    
                    //return value of current time
                    

                }

                

            }
       
        }

    }

    private void CupKiller ()
    {
        Destroy(Cup);
    }

    private void SmoothiePicker ()
    {
        smoothieSPA.x = smoothieSpawn.transform.position.x;
        smoothieSPA.y = smoothieSpawn.transform.position.y;
        smoothieSPA.z = smoothieSpawn.transform.position.z;


        Debug.Log("in smoothie picker");
        if (hasBananaCaul && hasStrawberryCaul)
        {
            Instantiate(StrBanana, smoothieSPA, Quaternion.identity);
            Debug.Log("in smoothie picker 111");
        }
        else if (hasBananaCaul && hasBlueberryCaul)
        {
            Instantiate(BananaSM, smoothieSPA, Quaternion.identity);
            Debug.Log("in smoothie picker 222");
        }
        else if (hasBlueberryCaul && hasStrawberryCaul)
        {
            Instantiate(StrawbSM, smoothieSPA, Quaternion.identity);
            Debug.Log("in smoothie picker333");
        }else
        {
            Instantiate(mistake, smoothieSPA, Quaternion.identity);
            Debug.Log("in smoothie picker mistake");
        }
        
    }
    
   
}
