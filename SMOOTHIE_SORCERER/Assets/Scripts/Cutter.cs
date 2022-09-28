using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
  public GameObject Knife;
  void OnTriggerEnter(Collider col)
  {
    if (col.gameObject.tag == "Slice" && Knife.GetComponent<Knife>().isCutting)
    {
      Knife.GetComponent<Knife>().SetCuttingState(true);
       
       col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //col.gameObject.GetComponent<Rigidbody>().AddTorque;

        

        GameSystem.System.OnVegetableCut();

        Destroy(col.gameObject, 4f);
        
    }
  }

}
