using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTap : MonoBehaviour
{
    private Animator anim;
    private GameObject PotionTapModel;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        PotionTapModel = transform.Find("PotionTapModel").gameObject;
        anim = PotionTapModel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
       {
        RaycastHit hit; 
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); 

        if (Physics.Raycast(ray, out hit, 10.0f)) 
        {
            if (hit.collider.tag == "Left")
            {
                anim.SetTrigger("Left");
            }
            else if (hit.collider.tag == "Middle")
            {
                anim.SetTrigger("Middle");
            }
            else if (hit.collider.tag == "Right")
            {
                anim.SetTrigger("Right");
            }

            
        }
       }
    }
}
