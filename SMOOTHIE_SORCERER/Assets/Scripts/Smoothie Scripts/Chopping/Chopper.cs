using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopper : MonoBehaviour
{
  public GameObject Knife;
  public GameObject CutFruitSpawnLocation;
  private Vector3 CutFruitVec;
  public float speed;
  private bool chopped;
  private Camera cam;

  public AudioClip chop1;
  public AudioClip chop2;
  public AudioClip chop3;
  public AudioClip chop4;
  public AudioClip chop5;

  public AudioSource audiosource;
  private IEnumerator coroutine;
  

  void Start ()
  {
   // audiosource = gameObject.GetComponent<AudioSource>();
    float randomNumber = Random.Range(1, 5);
    cam = Camera.main;
  }



  public void OnTriggerStay(Collider col)
  {
    //Debug.Log("recog");
    if (Input.GetMouseButtonDown(0)) 
        { 
            RaycastHit hit; 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); 
            Debug.DrawRay(transform.position, Input.mousePosition - transform.position, Color.blue);

            if (Physics.Raycast(ray, out hit, 10.0f)) 
            {
             if (hit.collider.tag == "ChoppingBoard")
             {
              Debug.Log("hit that board baby");
             if (Knife.GetComponent<Knife>().isCutting && col.gameObject.tag == "Slice") 
    {
     
      Knife.GetComponent<Knife>().SetCuttingState(true);
      // Debug.Log("Chopping board");
       //float randomNumber = Random.Range(1, 5);
      //ChooseAudio(randomNumber);
      
       col.gameObject.GetComponent<Animator>().SetBool("Chopped", chopped);
       chopped = true;
       col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
       col.gameObject.GetComponent<MoveableObject>().speed = 0;

    
      //instead of moving the oject we may consider spawning the objects cut variant -v
       CutFruitVec.x = CutFruitSpawnLocation.transform.position.x;
       CutFruitVec.y = CutFruitSpawnLocation.transform.position.y;
       CutFruitVec.z = CutFruitSpawnLocation.transform.position.z;

       col.gameObject.transform.position = CutFruitVec;
      

        

        GameSystem.System.OnVegetableCut();

        Destroy(col.gameObject, 4f);
        
    }
  }
            }
        }

  //  void ChooseAudio (float num)
  // {
  
  //   if (num == 1)
  //   audiosource.PlayOneShot(chop1, 0.7f);
    

  //   if (num == 2)
  //   audiosource.PlayOneShot(chop2, 0.7f);
    

  //   if (num == 3)
  //   audiosource.PlayOneShot(chop3, 0.7f);
   

  //   if (num == 4)
  //   audiosource.PlayOneShot(chop4, 0.7f);
    

  //   if (num == 5)
  //   audiosource.PlayOneShot(chop5, 0.7f);
   
  // }

  
  

}
}
  
