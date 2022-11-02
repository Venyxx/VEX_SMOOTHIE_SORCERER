using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHandManager : MonoBehaviour
{
    private Camera cam;
    private Vector3 raise;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            RaycastHit hit; 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out hit, 20.0f)) 
            {
                if (hit.collider.tag == "FinishedOrder") 
                {
                    var finishedOrder = hit.collider.gameObject;
                    
                    raise.x = finishedOrder.transform.position.x;
                    raise.y = finishedOrder.transform.position.y;
                    raise.z = finishedOrder.transform.position.z + 5;
                    finishedOrder.transform.position = Vector3.Lerp(finishedOrder.transform.position, raise, 3f * Time.deltaTime); 
                    Debug.Log("give to who?");

                     if (Input.GetMouseButtonDown(0)) 
                        { 
                            RaycastHit hitInternal; 
                            Ray rayInternal = cam.ScreenPointToRay(Input.mousePosition); 

                            if (Physics.Raycast(rayInternal, out hit, 10.0f)) 
                            {
                                if (hit.collider.tag == "Customer")
                                {
                                    Debug.Log("oh give to them");
                                } 

                            }
                            else 
                            {
                                Debug.Log("thats not a customer");
                            }
                        }
                }
            }
        }
    }
}
