using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedManager : MonoBehaviour
{
    public List<bool> trayBools = new List<bool> { false, false, false};
    public List<Transform> traySlots;
    public List<GameObject> traySlotsGameObjects;

    void Start ()
    {
        foreach (Transform i in traySlots)
        {
            traySlotsGameObjects.Add(i.gameObject);
        }
        
    }
    
}
