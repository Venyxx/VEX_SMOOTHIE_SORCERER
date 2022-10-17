using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBehaviors : MonoBehaviour
{
    public CinemachineVirtualCamera frontCamera;
    public CinemachineVirtualCamera backCamera;
    public bool isFacingFront;
    // Start is called before the first frame update
    void Start()
    {
        frontCamera.gameObject.SetActive(true);
        isFacingFront = true;
        backCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && isFacingFront == true)
        {
            Debug.Log("noticed input to back");
            backCamera.gameObject.SetActive(true);
            Invoke ("CameraBool", 0.1f);
            
        }
        else if (Input.GetKeyDown(KeyCode.C) && isFacingFront == false)
        {
            Debug.Log("noticed input to front");
            backCamera.gameObject.SetActive(false);
            Invoke ("CameraBool", 0.1f);
            
        }
    }

    void CameraBool ()
    {
        if (isFacingFront)
        {
            isFacingFront = false;
            //Debug.Log("changed front to false");
        }
        else if (!isFacingFront)
        {
           isFacingFront = true; 
            //Debug.Log("changed front to true");
        }
        
    }
}
