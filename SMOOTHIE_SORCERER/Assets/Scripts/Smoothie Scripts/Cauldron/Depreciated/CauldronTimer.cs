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

            if (percent > .75 && percent <= .99)
            {
                imageRef.color = Color.green;
            }
            else if (percent > .99)
            {
                imageRef.color = Color.red;
            }
            else 
            {
                imageRef.color = Color.white;
            }

        
    }

    private void Timer ()
    {

    }
}
