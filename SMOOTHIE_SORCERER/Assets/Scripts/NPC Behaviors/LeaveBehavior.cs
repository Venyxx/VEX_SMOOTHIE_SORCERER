using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBehavior : MonoBehaviour
{
    private RailWaypointNav characterREF;
    private Rigidbody rb;
    private GameObject CharacterModel;
    private Animator anim;

    private bool polyLeave;
    private bool speedLeave;
    private bool invisLeave;

    // Start is called before the first frame update
    void Start()
    {
        characterREF = gameObject.GetComponent<RailWaypointNav>();
        CharacterModel = transform.Find("Character_Animated").gameObject;
        anim = CharacterModel.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (characterREF.isLeaving == true && characterREF.nextWayPointIndex < 4)
        {
         characterREF.nextWayPointIndex ++;
         
         anim.SetFloat("Blend", 0);
        }
    }
}
