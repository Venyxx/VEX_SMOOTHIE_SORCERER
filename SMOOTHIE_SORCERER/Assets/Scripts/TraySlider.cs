using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraySlider : MonoBehaviour
{
    private GameObject cameraHandler;
    private GameObject frontTray;
    private GameObject backTray;
    public float speed;

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
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, frontTray.transform.position, speed * Time.deltaTime);
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, frontTray.transform.rotation, speed * Time.deltaTime);

       } else
       {
        //Debug.Log("tray back");
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, backTray.transform.position, speed  * Time.deltaTime);
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, backTray.transform.rotation, speed * Time.deltaTime);
        
       }
    }
}
