using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField] public float speedMetersPerSecond = 1.5f;

    private Vector3? destination;
    private Vector3 startPosition;
    private float totalLerpDuration;
    private float elapsedLerpDuration;
    public RailWaypointNav RailWaypointNavREF; 

    

    private Action onCompleteCallback;

    private void Update ()
    {
  
        if (destination.HasValue ==false)
        {
            Debug.Log("returning1");
            return;
        }

        if (elapsedLerpDuration>= totalLerpDuration && totalLerpDuration > 0)
        {
            //Debug.Log("returning2");
            //return;
        }


        elapsedLerpDuration += Time.deltaTime;
        float percent = (elapsedLerpDuration / totalLerpDuration);
        
        transform.position = Vector3.Lerp (startPosition, destination.Value, percent);

        if (elapsedLerpDuration >= totalLerpDuration)
        {
            onCompleteCallback?.Invoke();
        }
    } 
    

    public void MoveTo (Vector3 methodDestination, Action onComplete = null)
    {
        var distanceToNextWayPoint = Vector3.Distance(transform.position, methodDestination);
        totalLerpDuration = distanceToNextWayPoint / speedMetersPerSecond;

        startPosition = transform.position;
        destination = methodDestination;

        elapsedLerpDuration = 0f;
        onCompleteCallback = onComplete;
    }
}
