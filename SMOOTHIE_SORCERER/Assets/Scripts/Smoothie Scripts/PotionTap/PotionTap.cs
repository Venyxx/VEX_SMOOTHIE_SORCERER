using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTap : MonoBehaviour
{
    private Animator anim;
    private GameObject PotionTapModel;
    private Camera cam;
    private GameObject smoothie;
    private CupHolder smoothieREF;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        PotionTapModel = transform.Find("PotionTapModel").gameObject;
        anim = PotionTapModel.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "CupFull")
        {
            Debug.Log("saw the beertap smoothie");
            smoothie = col.gameObject;
            smoothieREF = smoothie.GetComponent<CupHolder>();
        }


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
                smoothieREF.hasInvis = true;
                Debug.Log("invis");
            }
            else if (hit.collider.tag == "Middle")
            {
                anim.SetTrigger("Middle");
                smoothieREF.hasPoly = true;
                Debug.Log("polym");
            }
            else if (hit.collider.tag == "Right")
            {
                anim.SetTrigger("Right");
                smoothieREF.hasSpeed = true;
                Debug.Log("speed");
            }

            
        }
       }
    }

    void SwapSmoothies()
    {
        if (smoothieREF.hasInvis)
        {
            
        }
    }
}
