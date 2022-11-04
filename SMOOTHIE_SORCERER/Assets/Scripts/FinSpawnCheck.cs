using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinSpawnCheck : MonoBehaviour
{
    private CupHolder finishedREF;

    // Start is called before the first frame update
    void Start ()
    {
        finishedREF = gameObject.GetComponent<CupHolder>();
    }


    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "FinishedSmoothie" && gameObject.name == "Spawn1")
        {
            finishedREF.trayBools[0] = true;
            Debug.Log("smoothie pos 1");

        } else if (col.gameObject.tag == "FinishedSmoothie" && gameObject.name == "Spawn2")
        {
            finishedREF.trayBools[1] = true;
            Debug.Log("smoothie pos 2");
        }
        else if (col.gameObject.tag == "FinishedSmoothie" && gameObject.name == "Spawn3")
        {
            finishedREF.trayBools[1] = true;
            Debug.Log("smoothie pos 3");
        }
    }

    void OnTriggerExit (Collider col)
    {
        if (col.gameObject.tag == "FinishedSmoothie" && gameObject.name == "Spawn1")
        {
            finishedREF.trayBools[0] = false;
            Debug.Log(" no smoothie pos 1");

        } else if (col.gameObject.tag == "FinishedSmoothie" && gameObject.name == "Spawn2")
        {
            finishedREF.trayBools[1] = false;
            Debug.Log(" no smoothie pos 2");
        }
        else if (col.gameObject.tag == "FinishedSmoothie" && gameObject.name == "Spawn3")
        {
            finishedREF.trayBools[1] = false;
            Debug.Log(" no smoothie pos 3");
        }
    }

}
