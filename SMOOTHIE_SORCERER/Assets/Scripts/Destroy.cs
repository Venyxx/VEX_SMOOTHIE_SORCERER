using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnTriggerEnter(Collider collidedObject)
    {
        Destroy(collidedObject.gameObject);
    }
}
