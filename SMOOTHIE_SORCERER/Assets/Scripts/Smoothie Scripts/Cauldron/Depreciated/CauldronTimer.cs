using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private Image imageRef;
    
    

    
    public CauldronBlending cauldronREF; 

    void Start()
    {
        
        imageRef = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
 
            float percent = cauldronREF.currentTime/cauldronREF.maxWellBlended;
            imageRef.fillAmount = percent;

        
    }

    private void Timer ()
    {

    }
}
