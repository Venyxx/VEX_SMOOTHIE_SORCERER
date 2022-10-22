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

    public List<Transform> waypoints;
    public List<Transform> seats;

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
    }
    private void OnEnable ()
    {
        
            waypoints = pathHolder.GetComponentsInChildren<Transform>().ToList(); 
            seats = seatHolder.GetComponentsInChildren<Transform>().ToList(); 
            waypoints.RemoveAt(index: 0);
            MoveToNextWaypoint();

            
            
        
    }

    private void Update()
    {
        if (seated)
        {
            Invoke ("FaceCounter", 1f);
        }
            
    }

    private void MoveToNextWaypoint ()
    {
        if (nextWayPointIndex == waypoints.Count) // reached the waiting, to be seated, area
        {
            //Debug.Log("reached waiting point");
            waiting = true;

            if (SeatChecker.seat1 == false)
            {
                var seatWayPoint = seats[0];
                target.MoveTo(seatWayPoint.position, MoveToNextWaypoint);
                target.transform.LookAt(seatWayPoint.position);
                seated = true;
            }

            //make the rules for all the other seats


        }
        else if (nextWayPointIndex < waypoints.Count) // keep moving along
        {
            Debug.Log("keep moving");
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
}
