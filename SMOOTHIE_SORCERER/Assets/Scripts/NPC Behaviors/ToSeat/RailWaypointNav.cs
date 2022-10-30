using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RailWaypointNav : MonoBehaviour
{
    [SerializeField] private Moveable target;
    [SerializeField] public bool waiting;
    [SerializeField] public bool seated;
    [SerializeField] public bool canOrder;
    [SerializeField] public bool clickedStartingOrder;
    [SerializeField] public bool isLeaving;
    private bool hasSeat;

    public List<Transform> waypoints;
    public List<Transform> seats;
    public List<GameObject> seatsGameObjects;

    public GameObject pathHolder;
    public GameObject seatHolder;
    public GameObject player;

    private int nextWayPointIndex;
    private SeatChecker SeatChecker;
    

    private void Start ()
    {
        GameObject seatManager = GameObject.FindGameObjectWithTag("SeatingManager"); 
        SeatChecker = seatManager.GetComponent<SeatChecker>(); 
        seated = false;

        foreach (Transform seat in seats)
        {
            seatsGameObjects.Add(seat.gameObject);
        }
        Debug.Log(seatsGameObjects);

    }


    private void OnEnable ()
    {
        
            waypoints = pathHolder.GetComponentsInChildren<Transform>().ToList(); 
            seats = seatHolder.GetComponentsInChildren<Transform>().ToList(); 
            seats.RemoveAt(index: 0);
            waypoints.RemoveAt(index: 0);
            MoveToNextWaypoint();
    }

    private void Update()
    {
        if (seated)
        {
            Invoke ("FaceCounter", 3f);
        }
            
    }

    private void MoveToNextWaypoint ()
    {
        if (nextWayPointIndex == waypoints.Count) // reached the waiting, to be seated, area
        {
            
            waiting = true;
            ChoosingSeat();

        }
        else if (nextWayPointIndex < waypoints.Count) // keep moving along
        {
            //Debug.Log("keep moving");
            var targetWayPointTransform = waypoints[nextWayPointIndex];
            target.MoveTo(targetWayPointTransform.position, MoveToNextWaypoint);

            target.transform.LookAt(waypoints[nextWayPointIndex].position); //CURRENTLY CHANGES LOOK DIRECTION

            nextWayPointIndex++;
        }
        
        
    }

    private void FaceCounter()
    {
        target.transform.LookAt(player.transform.position);
        canOrder = true;
        //Debug.Log(canOrder);
    }

    private void ChoosingSeat ()
    {

         if (!seated)
         {
            foreach (Transform seat in seats)
            {
                if (seat.gameObject.GetComponent<SeatItself>().hasCustomer == false)
                {
                    var seatWayPoint = seat.gameObject;
                    target.MoveTo(seatWayPoint.transform.position, MoveToNextWaypoint);
                    target.transform.LookAt(seatWayPoint.transform.position);
                    seated = true;

                    break;   
                }
            }
            
         }
             
    }
}
