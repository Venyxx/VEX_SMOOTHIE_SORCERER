using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwipeRecog : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public CinemachineVirtualCamera frontCamera;
    public CinemachineVirtualCamera backCamera;



    public GameObject cameraHolder;
    // Start is called before the first frame update
    void Start()
    {
        frontCamera.gameObject.SetActive(true);
        backCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.y < startTouchPosition.y)
            {
                //change camera behavior to point back counter
                Debug.Log("noticed input to back");
                backCamera.gameObject.SetActive(true);
            
            }

            if (endTouchPosition.y > startTouchPosition.y)
            {
                //face the front
                Debug.Log("noticed input to front");
                backCamera.gameObject.SetActive(false);
                
            }

            
        }
    }

     
}
