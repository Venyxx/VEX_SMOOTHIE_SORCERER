using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraySlider : MonoBehaviour
{
    private GameObject cameraHandler;
    private GameObject frontTray;
    private GameObject backTray;

    //public Transform [] smoothieSlots;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraHandler = GameObject.Find("CameraHandler");
        frontTray = GameObject.Find("frontTray");
        backTray = GameObject.Find("backTray");
    }

    // Update is called once per frame
    void Update()
    {
       if(cameraHandler.GetComponent<SwipeRecog>().isFacingFront)
       {
        //Debug.Log("moving tray to front");
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, frontTray.transform.position, 3f * Time.deltaTime);

       } else
       {
        //Debug.Log("tray back");
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, backTray.transform.position, 3f  * Time.deltaTime);
        
       }
    }
}
