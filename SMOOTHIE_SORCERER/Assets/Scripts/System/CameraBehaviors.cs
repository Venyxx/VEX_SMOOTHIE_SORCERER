using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBehaviors : MonoBehaviour
{
    public CinemachineVirtualCamera frontCamera;
    public CinemachineVirtualCamera backCamera;
    private SwipeRecog swipeScript;
    //public bool isFacingFront;
    // Start is called before the first frame update
    void Start()
    {
        swipeScript = gameObject.GetComponent<SwipeRecog>();
        frontCamera.gameObject.SetActive(true);
        swipeScript.isFacingFront = true;
        backCamera.gameObject.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.C) && swipeScript.isFacingFront == true)
        {
            //Debug.Log("noticed input to back");
            backCamera.gameObject.SetActive(true);
            Invoke ("CameraBool", 0.1f);
            
        }
        else if (Input.GetKeyDown(KeyCode.C) && swipeScript.isFacingFront == false)
        {
            //Debug.Log("noticed input to front");
            backCamera.gameObject.SetActive(false);
            Invoke ("CameraBool", 0.1f);
            
        }
    }

    void CameraBool ()
    {
        if (swipeScript.isFacingFront)
        {
            swipeScript.isFacingFront = false;
            //Debug.Log("changed front to false");
        }
        else if (!swipeScript.isFacingFront)
        {
           swipeScript.isFacingFront = true; 
            //Debug.Log("changed front to true");
        }
        
    }
}
