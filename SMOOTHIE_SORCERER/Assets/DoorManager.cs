using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
  private AudioSource audiosource;
  public AudioClip ding;

  void OnTriggerEnter (Collider col)
  {
    if (col.gameObject.tag == "Customer" && col.gameObject.GetComponent<RailWaypointNav>().isLeaving == false)
    {
       audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.PlayOneShot(ding, 0.7f); 
    }
    
  }
}
