using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RailWaypointNav : MonoBehaviour
{
    [SerializeField] private Moveable target;

    public List<Transform> waypoints;
    public GameObject pathHolder;
    private int nextWayPointIndex;

    private void OnEnable ()
    {
        
            waypoints = pathHolder.GetComponentsInChildren<Transform>().ToList(); 
            waypoints.RemoveAt(index: 0);
            MoveToNextWaypoint();
            
        
    }

    private void MoveToNextWaypoint ()
    {
        var targetWayPointTransform = waypoints[nextWayPointIndex];
        target.MoveTo(targetWayPointTransform.position, MoveToNextWaypoint);

        target.transform.LookAt(waypoints[nextWayPointIndex].position); //CURRENTLY CHANGES LOOK DIRECTION

        nextWayPointIndex++;
        if (nextWayPointIndex >= waypoints.Count)
        {
            nextWayPointIndex = 0;
        }
    }
}
