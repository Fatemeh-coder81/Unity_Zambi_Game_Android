using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomeGameEvnt : UnityEvent< object > { }

public class Event_Lisener : MonoBehaviour
{
    public Event_Holder Event_Holder;

    public CustomeGameEvnt Response;

    private void OnEnable()
    {
        Event_Holder.Register_Lesener(this);
    }

    private void OnDisable()
    {
        Event_Holder.On_Register_Lesener(this);
    }

    public void On_Event_Rised( object data )
    {
        Response.Invoke( data);
    }
}
