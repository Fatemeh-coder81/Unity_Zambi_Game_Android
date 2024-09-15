using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zambi_handler : MonoBehaviour
{

    public Transform[] waypoints;  // آرایه‌ای از نقاط مسیر
    public float baseSpeed = 3.0f; // سرعت پایه حرکت زامبی
    public float waypointThreshold = 0.1f;  // فاصله‌ای که زامبی باید به نقطه مسیر برسد تا به نقطه بعدی برود

    private int currentWaypointIndex = 0;
    private float speed;
    public Vector3 targetPosition;
    private float randomOffsetX;
    private float randomOffsetZ;

    public bool Move = false;
    void Start()
    {
        // تنظیم سرعت با یک مقدار تصادفی بین -0.5 و 0.5
        baseSpeed = baseSpeed + Random.Range(-1f, 25f);
   
    }

    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            MoveTowardsWaypoint();
        }
    }

  public void SetNextTarget()
    {

        if (Move)
        {
            // اضافه کردن تغییرات تصادفی به مختصات X و Z نقطه مسیر
            randomOffsetX = Random.Range(0f, 10f);
            randomOffsetZ = Random.Range(0f, 15f);


            targetPosition = new Vector3(waypoints[currentWaypointIndex].position.x - randomOffsetX,
                                        waypoints[currentWaypointIndex].position.y, 
                                         waypoints[currentWaypointIndex].position.z - randomOffsetZ);


        }
    }




    void MoveTowardsWaypoint()
    {
        if (Move == true)
        {
           

            // محاسبه جهت حرکت به سمت نقطه مسیر
            Vector3 direction = new Vector3(targetPosition.x - transform.position.x,
                                            0,
                                            targetPosition.z - transform.position.z);
        
            Vector3 moveVector = direction.normalized * baseSpeed * Time.deltaTime;

            // حرکت دادن زامبی با استفاده از transform.Translate
            transform.Translate(moveVector, Space.World);

            // چرخش به سمت نقطه مسیر
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, baseSpeed * Time.deltaTime);
            }

            // بررسی اینکه آیا زامبی به نقطه مسیر رسیده است یا نه
            if (direction.magnitude < waypointThreshold)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex < waypoints.Length)
                {
                    SetNextTarget();
                }
                else
                {
                    GetComponent<Animator>().SetTrigger("Attack");
                }
            }

        }
    }


}
