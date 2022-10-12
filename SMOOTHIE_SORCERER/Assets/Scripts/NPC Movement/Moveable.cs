using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField] private float speedMetersPerSecond = 25f;

    private Vector3? destination;
    private Vector3 startPosition;
    private float totalLerpDuration;
    private float elapsedLerpDuration;

    

    private Action onCompleteCallback;

    private void Start ()
    {
        
    }

    private void Update ()
    {
        
        
        
        if (destination.HasValue ==false)
        {
            return;
        }

        if (elapsedLerpDuration>= totalLerpDuration && totalLerpDuration > 0)
        {
            return;
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
