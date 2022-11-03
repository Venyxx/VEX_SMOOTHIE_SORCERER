using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHolder : MonoBehaviour
{
        [Header("Fruits--------------")]
        public bool hasBananaCup;
        public bool hasBlueberryCup;
        public bool hasStrawberryCup;

        [Header("Effects---------------")]
        public bool hasSpeed;
        public bool hasInvis;
        public bool hasPoly;

        [Header("Finished Smoothie Spawns")]
        public bool finished;
        public GameObject Invisible;
        public GameObject PolyCup;
        public GameObject SpeedCup;
        public Transform[] finishCups;

        [SerializeField] public float Value; 

        private GameObject tray;
        Material smoothieMaterial;

        
        
    
    // Start is called before the first frame update
    void Start()
    {
        Value = 6.0f;
         bool hasBananaCup = false;
         bool hasBlueberryCup = false;
         bool hasStrawberryCup = false;
         bool finished = false;
         
         tray = GameObject.Find("Tray");

        // moveSpots = gameObject.name = "Spawn1";

         
    }

    // Update is called once per frame
    

    public void OnTriggerEnter (Collider col)
    {
       

         if (col.gameObject.name == "Banana(Clone)")
          {
             hasBananaCup = true;
             

          }

          if (col.gameObject.name == "Strawberry_export(Clone)")
          {
            hasStrawberryCup = true;
          }

          if (col.gameObject.name == "Blueberry(Clone)")
          {
            hasBlueberryCup = true;
          }

          if(col.gameObject.tag == "FinishSMTH")
          {
            finished = true;
          }

    }

    void Update()
    {
        if (hasPoly == true)
        {
          transform.position =  new Vector3(0.5f,0.7f,-4.5f);
          GameObject theNewSmoothie = Instantiate(PolyCup, new Vector3(0.5f,0.4f,-4.5f), Quaternion.identity);
          theNewSmoothie.transform.parent = tray.transform;

            //this section is just long because i dont want to set up proper methods
            if (hasStrawberryCup && hasBananaCup)
            {
            var smoothiePart = theNewSmoothie.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s1");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("yellow");

            

            } else if (hasBananaCup && hasBlueberryCup)
            {
            var smoothiePart = theNewSmoothie.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s2");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("blue");
            }
             else if (hasBlueberryCup && hasStrawberryCup)
            {
            var smoothiePart = theNewSmoothie.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s3");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("red");
            }

            var newSMTHScript = theNewSmoothie.GetComponent<FinishedSmoothie>();
            newSMTHScript.hasBananaFIN = hasBananaCup;
            newSMTHScript.hasStrawberryFIN = hasStrawberryCup;
            newSMTHScript.hasBlueberryFIN = hasBlueberryCup;
            newSMTHScript.SmoothieValue = Value;

          Destroy(gameObject);
        }
        else if (hasInvis == true)
        {
          GameObject theNewSmoothie  = Instantiate(Invisible, new Vector3(0.5f,0.85f,-4.20f), Quaternion.identity);
          theNewSmoothie.transform.parent = tray.transform;

          //this section is just long because i dont want to set up proper methods
            if (hasStrawberryCup && hasBananaCup)
            {
            var smoothiePart = theNewSmoothie.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s1");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("yellow");



            } else if (hasBananaCup && hasBlueberryCup)
            {
            var smoothiePart = theNewSmoothie.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s2");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("blue");
            }
             else if (hasBlueberryCup && hasStrawberryCup)
            {
            var smoothiePart = theNewSmoothie.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s3");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("red");
            }

            var newSMTHScript = theNewSmoothie.GetComponent<FinishedSmoothie>();
            newSMTHScript.hasBananaFIN = hasBananaCup;
            newSMTHScript.hasStrawberryFIN = hasStrawberryCup;
            newSMTHScript.hasBlueberryFIN = hasBlueberryCup;
            newSMTHScript.SmoothieValue = Value;
          Destroy(gameObject);


        }
        else if (hasSpeed == true)
        {
          GameObject theNewSmoothie = Instantiate(SpeedCup, new Vector3(0.5f,0.85f,-4.20f), Quaternion.identity);
          theNewSmoothie.transform.parent = tray.transform;
          //this section is just long because i dont want to set up proper methods
            if (hasStrawberryCup && hasBananaCup)
            {
            var smoothiePart = theNewSmoothie.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s1");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("yellow");

            } else if (hasBananaCup && hasBlueberryCup)
            {
            var smoothiePart = theNewSmoothie.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s2");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("blue");
            }
             else if (hasBlueberryCup && hasStrawberryCup)
            {
            var smoothiePart = theNewSmoothie.transform.Find("smoothie").gameObject;
            smoothieMaterial = Resources.Load<Material>("s3");
            MeshRenderer mat = smoothiePart.GetComponent<MeshRenderer>();      
            mat.material = smoothieMaterial;
            Debug.Log("red");
            }

            var newSMTHScript = theNewSmoothie.GetComponent<FinishedSmoothie>();
            newSMTHScript.hasBananaFIN = hasBananaCup;
            newSMTHScript.hasStrawberryFIN = hasStrawberryCup;
            newSMTHScript.hasBlueberryFIN = hasBlueberryCup;
            newSMTHScript.SmoothieValue = Value;
          Destroy(gameObject);


        }
    }
}
