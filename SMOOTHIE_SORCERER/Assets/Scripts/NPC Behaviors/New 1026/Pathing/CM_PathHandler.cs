using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_PathHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> waitingQueuePositionList = new List<Vector3>();
        Vector3 firstPosition = new Vector3 (-1, 0, 3);
        float positionSize = 8f;
        for (int i = 0; i < 5; i++)
        {
            waitingQueuePositionList.Add(firstPosition + new Vector3 ( -1, 0) * positionSize * i);
        }
        new CM_WaitingQueue(waitingQueuePositionList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
