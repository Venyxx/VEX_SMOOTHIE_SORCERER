using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerEnter (Collider col)
   {
    if (col.tag == "Customer")
    {
        Destroy(col.gameObject);
    }
   }
}
