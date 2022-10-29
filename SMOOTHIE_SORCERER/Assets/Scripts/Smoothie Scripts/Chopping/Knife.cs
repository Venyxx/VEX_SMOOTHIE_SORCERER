using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Rect screenBounds;
    public bool isCutting;
    //public CameraBehaviors Cam;
    //public TMP_Text ChopState;
    private Camera cam;
    private Animator anim;
    public ParticleSystem chopParticle;
    private GameObject particleSpawn;
    

    public float TimeElapsed = 0f;
    private float ClickTimeFrame = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        screenBounds = new Rect(0, 0, Screen.width, Screen.height - 200);
        anim = gameObject.GetComponent<Animator>();
        particleSpawn = GameObject.Find("PoofSpawn");
        //Debug.Log(particleSpawn);
    }

    public void SetCuttingState(bool state)
    {
        isCutting = state;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0) && screenBounds.Contains(Input.mousePosition) && isCutting == false)
        {
            TimeElapsed = 0f;
            SetCuttingState(true);
            //Debug.Log("chop");
            anim.SetTrigger("Chopper");
            Instantiate (chopParticle, particleSpawn.transform);
            
            //ChopState.text = "Chopping";
        }
        else
        {
            TimeElapsed += Time.fixedDeltaTime;
            if (TimeElapsed >= ClickTimeFrame && isCutting)
            {
                SetCuttingState(false);
                TimeElapsed = 0f;
                
                //ChopState.text = "Not Chopping";
            }
            
        }

        
    }
}
