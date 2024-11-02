using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar_Handler : MonoBehaviour
{
   
    public Tower_Controler _controler;

    private void Awake()
    {
      
    }




    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        _controler.enemies.Add(other.transform);
    //        _controler.Set_Target();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        _controler.enemies.Remove(other.transform);
    //        _controler.Set_Target();
    //    }
    //}
}
