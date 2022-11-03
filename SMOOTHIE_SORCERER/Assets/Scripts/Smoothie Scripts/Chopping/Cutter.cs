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

  public AudioClip chop1;
  public AudioClip chop2;
  public AudioClip chop3;
  public AudioClip chop4;
  public AudioClip chop5;

  private AudioSource audiosource;
  private IEnumerator coroutine;

   public GameObject CameraHandler;
  public SwipeRecog swipeRecog;
  

  void Start ()
  {
    audiosource = gameObject.GetComponent<AudioSource>();
    float randomNumber = Random.Range(1, 5);
  }



  void OnTriggerStay(Collider col)
  {
    //Debug.Log("recog");
    if (swipeRecog.isFacingFront == false)
    {
    if (col.gameObject.tag == "Slice" && Knife.GetComponent<Knife>().isCutting)
    {
      
      Knife.GetComponent<Knife>().SetCuttingState(true);
      float randomNumber = Random.Range(1, 5);
      ChooseAudio(randomNumber);
      
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

   void ChooseAudio (float num)
  {
  
    if (num == 1)
    audiosource.PlayOneShot(chop1, 0.7f);
    

    if (num == 2)
    audiosource.PlayOneShot(chop2, 0.7f);
    

    if (num == 3)
    audiosource.PlayOneShot(chop3, 0.7f);
   

    if (num == 4)
    audiosource.PlayOneShot(chop4, 0.7f);
    

    if (num == 5)
    audiosource.PlayOneShot(chop5, 0.7f);
   
  }

  
  

}
}