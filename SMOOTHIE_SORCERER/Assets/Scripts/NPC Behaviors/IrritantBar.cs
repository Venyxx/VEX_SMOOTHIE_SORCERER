using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IrritantBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Image imageRef;
    private float currentIrritant;
    public float maxIrritant;
    

    
    public RailWaypointNav customerREF; 

    void Start()
    {
        
        imageRef = GetComponent<Image>();
        customerREF.isLeaving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (customerREF.canOrder == true)
        {
            currentIrritant += Time.deltaTime;

            float percent = currentIrritant/maxIrritant;
            imageRef.fillAmount = percent;
            if (currentIrritant == maxIrritant)
                 {
                     customerREF.isLeaving = true;
                 }
        }
        
    }

    private void Timer ()
    {

    }
}
