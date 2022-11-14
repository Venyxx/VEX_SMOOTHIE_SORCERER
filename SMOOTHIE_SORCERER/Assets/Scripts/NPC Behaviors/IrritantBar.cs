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
    
    public Sprite happy;
    public Sprite mid;
    public Sprite sad;

    float percent; 
    
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

             percent = currentIrritant/maxIrritant;
            imageRef.fillAmount = percent;
            if (currentIrritant >= maxIrritant)
                 {
                     customerREF.isLeaving = true;
                 }
        }

        if (percent < .33)
        {
            imageRef.sprite = happy;
            imageRef.color = new Color32(153, 255, 153, 100);
        }
        else if (percent > .33 && percent < .66)
        {
            imageRef.sprite = mid;
            imageRef.color = new Color32(255, 255, 153, 100);
        }
        else if (percent > .66)
        {
            imageRef.sprite = sad;
            imageRef.color = new Color32(255, 77, 77, 100);
        }
        
    }

    private void Timer ()
    {

    }
}
