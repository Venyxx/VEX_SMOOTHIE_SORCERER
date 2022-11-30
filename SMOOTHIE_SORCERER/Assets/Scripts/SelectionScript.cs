using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
     public string selectableTag = "FinishedOrder";
    //[SerializeField] private Material HighLightMaterial;
    //[SerializeField] private Material DefaultMaterial;
    public Camera cam;
    public SwipeRecog swipe;
    public buttonServe ButtonServe;
    private Transform _selection;
    private GameObject localButtons;
    public GameObject selectedObject;

    void Start ()
    {
        localButtons = GameObject.Find("buttons");
        localButtons.SetActive(false);
        
    }

    private void Update()
    {
        
         if (Input.GetMouseButtonDown(0) && swipe.isFacingFront == true) 
         {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
         if (Physics.Raycast(ray, out hit, 10.0f))
        {
            GameObject hitObject = hit.transform.root.gameObject;
            SelectObject(hitObject);
            if (hit.collider.tag == "FinishedOrder" )
            {
                //Renderer r = selectedObject.GetComponent<Renderer>();
            
                Debug.Log("hit button check");
                localButtons.SetActive(true);
                ButtonServe.currentSmoothie = hit.collider.gameObject;
            }
        }
        }

        void SelectObject(GameObject obj)
        {
            if(selectedObject != null)
            {
                if(obj == selectedObject)
                return;

                ClearSelection();
            }
            selectedObject = obj;
            
            // Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
            // foreach(Renderer r in rs)
            // {
            //     Material m = r.material;
            //     m.color = Color.green;
            //     r.material = m;
            // }
        }

        void ClearSelection()
        {
            if(selectedObject == null)
            return;

            // Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
            // foreach(Renderer r in rs)
            // {
            //     Material m = r.material;
            //     m.color = Color.white;
            //     r.material = m;
            // }

            selectedObject = null;
        }
        // if (Physics.Raycast(ray, out hit, 10.0f))
        // {
        //     var selection = hit.transform;
        //     if(selection.CompareTag("FinishedOrder"))
        //     {
                
        //         var selectionRender = selection.GetComponent<Renderer>();
        //         if(selectionRender != null)
        //         {
        //             selectionRender.material = HighLightMaterial;
        //         }
                

        //         // ButtonServe.currentSmoothie = _selection;
        //     }
        // }
    }
}