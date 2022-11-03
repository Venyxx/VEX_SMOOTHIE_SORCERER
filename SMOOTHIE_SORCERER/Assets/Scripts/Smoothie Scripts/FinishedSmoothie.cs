using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedSmoothie : MonoBehaviour
{
        [SerializeField]public bool hasBananaFIN;
        [SerializeField]public bool hasBlueberryFIN;
        [SerializeField]public bool hasStrawberryFIN;
        [SerializeField]public float SmoothieValue;
    
    // Start is called before the first frame update
    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "FrontCounter")
        {
            gameObject.transform.parent = col.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
