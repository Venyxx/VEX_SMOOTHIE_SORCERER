using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraySlider : MonoBehaviour
{
    public Transform slot1;
    public Transform slot2;
    public Transform slot3;

    public Transform [] smoothieSlots;
    
    // Start is called before the first frame update
    void Start()
    {
        smoothieSlots[0] = slot1;
        smoothieSlots[1] = slot2;
        smoothieSlots[2] = slot3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
