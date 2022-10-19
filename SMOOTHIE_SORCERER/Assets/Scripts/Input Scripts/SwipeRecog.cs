using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRecog : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    public GameObject cameraHolder;
    // Start is called before the first frame update
    void Start()
    {
        
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
            endTsouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.y < startTouchPosition.y)
            {
                //change camera behavior to point back counter
                Debug.Log("face the back");
                
            }

            if (endTouchPosition.y > startTouchPosition.y)
            {
                //face the front
                Debug.Log("facing the front");
            }
        }
    }
}
