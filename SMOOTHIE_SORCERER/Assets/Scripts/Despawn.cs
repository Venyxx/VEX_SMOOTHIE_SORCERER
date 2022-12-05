using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    private GameSystem gameSystem;
    // Start is called before the first frame update
   void OnTriggerEnter (Collider col)
   {
    if (col.tag == "Customer")
    {
        Destroy(col.gameObject);
    } else if (col.tag == "CustomerMad")
    {
        gameSystem = GameObject.Find("Game System").GetComponent<GameSystem>();
        gameSystem.DecreaseHappyCustomers(1);
        Destroy(col.gameObject);
    }
   }
}
