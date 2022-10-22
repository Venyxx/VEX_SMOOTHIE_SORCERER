using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    [SerializeField] public bool orderStrawberry= false;
    [SerializeField] public bool orderBlueberry= false;
    [SerializeField] public bool orderBanana= false;

    [SerializeField] public int smoothieValue;
    // Start is called before the first frame update
    void Start()
    {
        smoothieValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
