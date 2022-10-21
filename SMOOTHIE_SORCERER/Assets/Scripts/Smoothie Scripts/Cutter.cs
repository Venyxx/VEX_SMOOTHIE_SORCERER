using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
  public GameObject Knife;
  public Transform CutFruit;
  public float speed;
  void OnTriggerStay(Collider col)
  {
    if (col.gameObject.tag == "Slice" && Knife.GetComponent<Knife>().isCutting)
    {
      Knife.GetComponent<Knife>().SetCuttingState(true);
       
       col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
       col.gameObject.GetComponent<MoveableObject>().speed = 0;
       col.gameObject.transform.position = new Vector3(0.734f, 1.416f, -3.966f);
        //col.gameObject.GetComponent<Rigidbody>().AddTorque;

        

        GameSystem.System.OnVegetableCut();

        Destroy(col.gameObject, 4f);
        
    }
  }

}
