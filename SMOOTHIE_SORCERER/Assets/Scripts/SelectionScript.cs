using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
     public string selectableTag = "FinishedOrder";
    [SerializeField] private Material HighLightMaterial;
    //[SerializeField] private Material DefaultMaterial;
    public Camera cam;
    public buttonServe ButtonServe;
    private Transform _selection;

    private GameObject localButtons;

    void Start ()
    {
        localButtons = GameObject.Find("buttons");
        localButtons.SetActive(false);

    }

    private void Update()
    {
        if(_selection != null)
        {
            var selectionRender = _selection.GetComponent<Renderer>();
          //  selectionRender.material = DefaultMaterial;
            _selection = null;
        }
        if (Input.GetMouseButtonDown(0)) 
        {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            if (hit.collider.tag == "FinishedOrder")
            {
                Debug.Log("hit button check");
                localButtons.SetActive(true);
                ButtonServe.currentSmoothie = hit.collider.gameObject;
            }
        }
        }
        // if (Physics.Raycast(ray, out hit))
        // {
        //     var selection = hit.transform;
        //     if(selection.CompareTag(selectableTag))
        //     {
        //         var selectionRender = selection.GetComponent<Renderer>();
        //         if(selectionRender != null)
        //         {
        //             selectionRender.material = HighLightMaterial;
        //         }
        //         _selection = selection;

        //         // ButtonServe.currentSmoothie = _selection;
        //     }
        // }
    }
}