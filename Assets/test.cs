using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject Ob;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.right, Ob.transform.position);
    }
}
