using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBehaviors : MonoBehaviour
{
    public CinemachineVirtualCamera frontCamera;
    public CinemachineVirtualCamera backCamera;
    // Start is called before the first frame update
    void Start()
    {
        //frontCamera.gameObject.SetActive(true);
        backCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && backCamera.gameObject == true)
        {
            Debug.Log("noticed input to front");
            backCamera.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.C) && backCamera.gameObject == false)
        {
            Debug.Log("noticed input to back");
            backCamera.gameObject.SetActive(false);
            
        }
    }
}
