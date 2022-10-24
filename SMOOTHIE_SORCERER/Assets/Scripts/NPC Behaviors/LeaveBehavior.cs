using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBehavior : MonoBehaviour
{
    private RailWaypointNav characterREF;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        characterREF = gameObject.GetComponent<RailWaypointNav>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterREF.isLeaving == true)
        {
            Debug.Log("theyre leaving");
            Destroy(gameObject);
            //Vector3 direction = (rb.transform.x, rb.transform.y, rb.transform.z);
            //rb.AddForce(direction, 10f);
        }
    }
}
