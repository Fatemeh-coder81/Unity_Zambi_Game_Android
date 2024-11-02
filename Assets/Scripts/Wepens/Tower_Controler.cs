//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Tower_Controler : MonoBehaviour
//{
//    public float Health = 100f;

//    public GameObject Bow_Base;
//    public GameObject Arrow_Prefab;
//    public Transform Shoot_Point;
//    public float Shoot_Power;
//    public float Shoot_Interval = 1f; // Cooldown between shots
//    [SerializeField]
//    private Transform currentTarget;
//    [SerializeField]
//    public List<Transform> enemies;
//    private float lastShotTime;


//    [Header("Ui : \n")]
//    [SerializeField]
//    private Image Life_Line;

//    public float Helf = 100;
//    void Start()
//    {
//        lastShotTime = -Shoot_Interval; // Allow immediate first shot
//    }

//    void Update()
//    {
//        if (currentTarget)
//        {
//            Bow_Base.transform.LookAt(currentTarget.transform.position);

//            Shot_Target();

//        }
//        else
//        {
//            // Reset the y rotation if no target is found
//            Bow_Base.transform.rotation = Quaternion.Slerp(Bow_Base.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 2f);
//        }
//    }

//    public void Find_Target()
//    {
//        if (currentTarget)
//        {
//            // Rotate base towards enemy on the y-axis
//            Vector3 direction = (currentTarget.position - Bow_Base.transform.position).normalized;
//            Bow_Base.transform.rotation = Quaternion.Slerp(Bow_Base.transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)), Time.deltaTime * 2f);
//        }
//    }

//    public void Shot_Target()
//    {
//        if (currentTarget && Time.time > lastShotTime + Shoot_Interval)
//        {

//            // Instantiate and shoot the arrow
//            GameObject arrow = Instantiate(Arrow_Prefab, Shoot_Point.position, Shoot_Point.rotation);
//            Rigidbody rb = arrow.GetComponent<Rigidbody>();
//            rb.velocity = (currentTarget.position - Shoot_Point.position).normalized * Shoot_Power;
//            Destroy(arrow, 0.5f);
//            lastShotTime = Time.time;

//        }
//    }

//    public void Set_Target()
//    {
//        if (enemies.Count > 0)
//        {
//            currentTarget = enemies[0];
//        }
//        else
//        {
//            currentTarget = null;
//        }
//    }


//    public bool Get_Dameg(float Dameg_Power)
//    {
//        Life_Line.fillAmount -= (Dameg_Power /100);

//        Helf -= Dameg_Power;

//        if (Helf <= 0)
//        {
//            Destroy(this.gameObject);


//           return false;
//        }
//        return true;
//    }

//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Controler : MonoBehaviour
{
    public float Health = 100f;

    public GameObject Bow_Base;
    public GameObject Arrow_Prefab;
    public Transform Shoot_Point;
    public float Shoot_Power;
    public float Shoot_Interval = 1f; // Cooldown between shots
    [SerializeField]
    private Transform currentTarget;
    [SerializeField]
    public List<Transform> enemies;
    private float lastShotTime;

    [Header("Raycast Settings")]
    public LayerMask enemyLayerMask; // Layer mask for enemy detection
    public float raycastLength = 20f; // Maximum length of the raycast
    public Transform wall; // The wall that defines the battlefield boundary

    [Header("Sound Settings")]
    public AudioSource audioSource;

    [Header("Ui : \n")]
    [SerializeField]
    private Image Life_Line;

    public float Helf = 100;

 
    void Start()
    {
        lastShotTime = -Shoot_Interval; // Allow immediate first shot
    }

    void Update()
    {
        FindAndSetTarget(); // Find and set the nearest target

        if (currentTarget)
        {
            Bow_Base.transform.LookAt(currentTarget.transform.position);
            Shot_Target();
        }
        else
        {
            // Reset the y rotation if no target is found
            Bow_Base.transform.rotation = Quaternion.Slerp(Bow_Base.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 2f);
        }
    }

    private void FindAndSetTarget()
    {
        currentTarget = null;
        float closestDistance = float.MaxValue;

        RaycastHit[] hits = Physics.RaycastAll(Shoot_Point.position, Vector3.left, raycastLength, enemyLayerMask);

        foreach (RaycastHit hit in hits)
        {
           
                float distanceToEnemy = Vector3.Distance(Shoot_Point.position, hit.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    currentTarget = hit.transform;
                }
            
        }
    }

    public void Shot_Target()
    {
        if (currentTarget && Time.time > lastShotTime + Shoot_Interval)
        {
            audioSource.Play();
            GameObject arrow = Instantiate(Arrow_Prefab, Shoot_Point.position, Shoot_Point.rotation);
            Rigidbody rb = arrow.GetComponent<Rigidbody>();

         
            Vector3 Target_Head = new Vector3(currentTarget.position.x, currentTarget.position.y + 0.1f, currentTarget.position.z);
    
            
            rb.velocity = (Target_Head - Shoot_Point.position).normalized * Shoot_Power;    
          
            Destroy(arrow, 0.5f);
            lastShotTime = Time.time;

         
            
        }
    }

    public bool Get_Dameg(float Dameg_Power)
    {
        Life_Line.fillAmount -= (Dameg_Power / 100);
        Helf -= Dameg_Power;

        if (Helf <= 0)
        {
            Destroy(this.gameObject);
            return false;
        }
        return true;
    }
}

