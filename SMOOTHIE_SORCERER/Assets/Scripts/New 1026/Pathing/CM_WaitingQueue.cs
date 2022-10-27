using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_WaitingQueue : MonoBehaviour
{
   private List<Vector3> positionList;
   private List <CM_Guest> guestList;
   private Vector3 entrancePosition;

   public CM_WaitingQueue(List<Vector3> positionList)
   {
        this.positionList = positionList;
        entrancePosition = positionList[positionList.Count - 1] + new Vector3(-8f, 0, 0);
        guestList = new List <CM_Guest>();
   }
    
    public bool CanAddGuest ()
    {
        return guestList.Count < positionList.Count;
    }

    public void AddGuest (CM_Guest guest)
    {
        guestList.Add(guest);
        guest.MoveTo(entrancePosition);//() => {guest.MoveTo(positionList[guestList.IndexOf(guest)]);});
    }

}


