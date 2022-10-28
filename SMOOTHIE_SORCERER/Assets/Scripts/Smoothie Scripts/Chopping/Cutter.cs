using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
  public GameObject Knife;
  public GameObject CutFruitSpawnLocation;
  private Vector3 CutFruitVec;
  public float speed;
  private bool chopped;



private IEnumerator coroutine;


  void OnTriggerStay(Collider col)
  {
    //Debug.Log("recog");
    if (col.gameObject.tag == "Slice" && Knife.GetComponent<Knife>().isCutting)
    {
      
      Knife.GetComponent<Knife>().SetCuttingState(true);
       
      
       col.gameObject.GetComponent<Animator>().SetBool("Chopped", chopped);
       chopped = true;
       col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
       col.gameObject.GetComponent<MoveableObject>().speed = 0;

      //coroutine = MoveFruit(col);
      //StartCoroutine(coroutine);

      //idk how COROUTINES WORK
      //instead of moving the oject we may consider spawning the objects cut variant -v
       CutFruitVec.x = CutFruitSpawnLocation.transform.position.x;
       CutFruitVec.y = CutFruitSpawnLocation.transform.position.y;
       CutFruitVec.z = CutFruitSpawnLocation.transform.position.z;

       col.gameObject.transform.position = CutFruitVec;
      //col.gameObject.GetComponent<Rigidbody>().AddTorque;

        

        GameSystem.System.OnVegetableCut();

        //Destroy(col.gameObject, 4f);
        
    }
  }

  //private IEnumerator MoveFruit()
  

}
