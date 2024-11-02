using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Holder")]

public class Event_Holder : ScriptableObject
{
    public List<Event_Lisener> Leseners = new List<Event_Lisener>();


    public void Rise( object data)
    {
        for (int i = 0; i < Leseners.Count; i++)
        {
            Leseners[i].On_Event_Rised( data);
        }
    }
    

    public void Register_Lesener(Event_Lisener Lesener)
    {
        if (!Leseners.Contains(Lesener))
        {
            Leseners.Add(Lesener);
        }
    }

    public void On_Register_Lesener(Event_Lisener Lesener)
    {
        if (Leseners.Contains(Lesener))
        {
            Leseners.Remove(Lesener);
        }
    }

}
