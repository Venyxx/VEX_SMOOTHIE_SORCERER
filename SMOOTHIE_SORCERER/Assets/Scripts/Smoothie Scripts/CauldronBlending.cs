using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


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
        public Camera cam;

        [SerializeField] public float CauldronValue;
        private GameObject Cup;
        private CupHolder cupREF;

    // Start is called before the first frame update
    public void Start()
    {
        wellBlended = false;
        overBlended = false;
    }

    public void Update()
    {
         if (Input.GetMouseButtonDown(0)) 
        { 
            RaycastHit hit; 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out hit, 10.0f)) 
            {
                if (hit.collider.tag == "Blender")
                {
                    Cup = GameObject.FindGameObjectWithTag("Cup");
                    cupREF = Cup.GetComponent<CupHolder>();

                    hasBananaCaul = cupREF.hasBananaCup;
                    hasStrawberryCaul = cupREF.hasStrawberryCup;
                    hasBlueberryCaul = cupREF.hasBlueberryCup;

                    CauldronValue = cupREF.Value;

                    //here is where we will set as child or just move transform relative to cauldron pos and run oneshot animation
                    // then despawn cup

               
                }

            }
       
        }
    }

    private void SmoothiePicker ()
    {
        if (hasBananaCaul && hasStrawberryCaul)
        {
            Instantiate(StrBanana);
        }
        else if (hasBananaCaul && hasBlueberryCaul)
        {
            //Instantiate();
        }
        else if (hasBlueberryCaul && hasStrawberryCaul)
        {
            //Instantiate();
        }
        
    }
    
   
}
