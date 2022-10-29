using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class CauldronBlending : MonoBehaviour
{
        [Header("Smoothie Value")]
        [SerializeField] public float CauldronValue;
        [Header("Ingredients")]
        public bool hasBananaCaul;
        public bool hasBlueberryCaul;
        public bool hasStrawberryCaul;

        [Header("Smoothie Prefabs")]
        public GameObject CupSmoothie;
        public GameObject mistake;
        public Transform smoothieSpawn;

         [Header("Timer")]
        public bool wellBlended;
        public bool overBlended;
 
        
        
        //public TextMeshProUGUI timerTextie;

        private Camera cam;

        private GameObject Cup;
        private GameObject beerTap;
        private CupHolder cupREF;
        private Transform cupMotive;
        
        private CauldronTimer caulTimREF;
        private Vector3 smoothieSPA;
        
        public float currentTime;
        
        
        public float maxWellBlended;
        [SerializeField] public bool isFinished;
        [SerializeField] public bool isBlending;

        Material smoothieMaterial;

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
        //timerTextie.text = currentTime.ToString("0");

        if (isFinished)
        {
            //here is where we instantiate the smoothie and attach the values;
            SmoothiePicker();
            isFinished = false;
            //Debug.Log("ran is finished");
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
                    //Debug.Log("tagged it");
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
                    //timer

                    isBlending = false;
                    isFinished = true;
                    
                    currentTime = 0;
                    //Debug.Log("sending value to smoothie");

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
        //this is silly but it works lol
        smoothieSPA.x = smoothieSpawn.transform.position.x;
        smoothieSPA.y = smoothieSpawn.transform.position.y;
        smoothieSPA.z = smoothieSpawn.transform.position.z;


        Debug.Log("in smoothie picker");
        if (hasBananaCaul && hasStrawberryCaul)
        {
            //spawn and set values
            GameObject fullCup = Instantiate(CupSmoothie, smoothieSPA, Quaternion.identity);
            fullCup.GetComponent<CupHolder>().hasStrawberryCup = hasStrawberryCaul;
            fullCup.GetComponent<CupHolder>().hasBlueberryCup = hasBlueberryCaul;
            fullCup.GetComponent<CupHolder>().hasBananaCup = hasBananaCaul;
            fullCup.GetComponent<CupHolder>().Value = CauldronValue;

            //change smoothie color
            var smoothiePart = fullCup.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s1");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("yellow");




        }
        else if (hasBananaCaul && hasBlueberryCaul)
        {
               //spawn and set values
            GameObject fullCup = Instantiate(CupSmoothie, smoothieSPA, Quaternion.identity);
            fullCup.GetComponent<CupHolder>().hasStrawberryCup = hasStrawberryCaul;
            fullCup.GetComponent<CupHolder>().hasBlueberryCup = hasBlueberryCaul;
            fullCup.GetComponent<CupHolder>().hasBananaCup = hasBananaCaul;
            fullCup.GetComponent<CupHolder>().Value = CauldronValue;

            //change smoothie color
            var smoothiePart = fullCup.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s2");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("blue");





        }  
        else if (hasBlueberryCaul && hasStrawberryCaul)
        {
              //spawn and set values
            GameObject fullCup = Instantiate(CupSmoothie, smoothieSPA, Quaternion.identity);
            fullCup.GetComponent<CupHolder>().hasStrawberryCup = hasStrawberryCaul;
            fullCup.GetComponent<CupHolder>().hasBlueberryCup = hasBlueberryCaul;
            fullCup.GetComponent<CupHolder>().hasBananaCup = hasBananaCaul;
            fullCup.GetComponent<CupHolder>().Value = CauldronValue;

            //change smoothie color
            var smoothiePart = fullCup.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s3");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("red");





        }
        else 
        {
              //spawn and set values
            GameObject fullCup = Instantiate(CupSmoothie, smoothieSPA, Quaternion.identity);
            fullCup.GetComponent<CupHolder>().hasStrawberryCup = hasStrawberryCaul;
            fullCup.GetComponent<CupHolder>().hasBlueberryCup = hasBlueberryCaul;
            fullCup.GetComponent<CupHolder>().hasBananaCup = hasBananaCaul;
            fullCup.GetComponent<CupHolder>().Value = CauldronValue;

            //change smoothie color
            var smoothiePart = fullCup.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s4");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("purple");
        }


        hasBananaCaul = false;
        hasStrawberryCaul = false;
        hasBlueberryCaul = false;
        
    }
    
   
}
