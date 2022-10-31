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
        public Transform[] finishCups;

        [SerializeField] public float Value; 

        
        
    
    // Start is called before the first frame update
    void Start()
    {
        Value = 6.0f;
         bool hasBananaCup = false;
         bool hasBlueberryCup = false;
         bool hasStrawberryCup = false;
         bool finished = false;
         

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
          // transform.position =  new Vector3(0.5f,0.7f,-4.5f);// * Time.deltaTime;
          Instantiate(PolyCup, new Vector3(0.5f,0.4f,-4.5f), Quaternion.identity);
          Destroy(gameObject);
        }
        else if (hasInvis == true)
        {
          Instantiate(Invisible, new Vector3(0.5f,0.85f,-4.20f), Quaternion.identity);
          Destroy(gameObject);
        }
    }
}
