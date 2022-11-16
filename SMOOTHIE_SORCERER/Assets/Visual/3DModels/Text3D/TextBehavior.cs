using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextBehavior : MonoBehaviour
{
    public GameObject Track;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Track.transform.position.x,this.transform.position.y,Track.transform.position.z);
    }
}
