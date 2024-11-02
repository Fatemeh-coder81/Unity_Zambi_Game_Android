using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EnemyMovment : MonoBehaviour
{
    public float moveSpeed = 2f;
   
    public string[] targetTags = { "Tower", "Castle" };
    public Animator animator;

    [SerializeField]
    private bool isAttacking = false;
    [SerializeField]
    private GameObject currentTarget;

    public float Dameg_Power;

    [Header("Life Controle : \n")]
    public float Helf = 100;
    public Image Life_Line;

    [Header("Price : \n")]
    public float Price = 100f;

    [SerializeField] private Event_Holder event_Holder;


    public bool End_Of_The_Path = false;
    public int Path_index = 0;

    public bool Move = false;


    public List<Transform> Target_Pos;

    public Enemy_Sponer Enemy_Sponer;

  
    private void Start()
    {
       
    }

    void Update()
    {


        if (Move == true)
        {


            // اگر دشمن به انتهای مسیر نرسیده باشد، مسیر را دنبال می‌کند
            if (End_Of_The_Path == false)
            {
                Fallow_Path();
            }


            //اگر دشمن در حال حمله باشد، هیچ حرکتی انجام نمی‌دهد
            if (isAttacking) return;

            //اگر هدفی وجود نداشته باشد، به جلو حرکت می‌کند
            if (currentTarget == null)
            {

                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                //    حرکت به سمت هدف
                transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, moveSpeed * Time.deltaTime);
                transform.LookAt(currentTarget.transform);

                //    بررسی فاصله تا هدف
                if (Vector3.Distance(transform.position, currentTarget.transform.position) < 0.1f)
                {
                    //        شروع به حمله
                    isAttacking = true;
                    Set_Animation_State(isAttacking);
                }
            }



        }
    }

    public void Fallow_Path()
    {
        if (End_Of_The_Path == false)
        {
            if (Path_index < Target_Pos.Count)
            {
                

                Vector3 direction = (Target_Pos[Path_index].position - transform.position).normalized;

                transform.LookAt(Target_Pos[Path_index].position);


                transform.position = Vector3.MoveTowards(transform.position, Target_Pos[Path_index].position, moveSpeed * Time.deltaTime);

                // بررسی رسیدن به نقطه بعدی مسیر
                if (Vector3.Distance(transform.position, Target_Pos[Path_index].position) < 0.01f)
                {
                    transform.position = Target_Pos[Path_index].position;
                   

                    Path_index += 1;
         
                    if (Path_index >= Target_Pos.Count)
                    {
                        transform.rotation = Quaternion.Euler(0, 90, 0);

                        End_Of_The_Path = true;
                    }
                }
            }
        }
    }


    // بررسی تگ هدف
    private bool IsTargetTag(string tag)
    {
        foreach (string targetTag in targetTags)
        {
            if (tag == targetTag) return true;
        }
        return false;
    }

    // این تابع باید از طریق انیمیشن کال شود (زمانی که انیمیشن حمله تمام می‌شود)
    public void StopAttacking()
    {
        isAttacking = false;
        Set_Animation_State(isAttacking);

        // اگر هدف نابود شده باشد
        if (currentTarget != null)
        {
            currentTarget = null;
        }
    }

    // مدیریت برخوردها
    private void OnTriggerEnter(Collider collision)
    {
        // دریافت آسیب از تیر
        if (collision.CompareTag("Arrow"))
        {
            Get_Dameg(collision.gameObject);
        }

        // بررسی تگ هدف و شروع حمله
        if (IsTargetTag(collision.tag))
        {
            currentTarget = collision.gameObject;
            isAttacking = true;
            Set_Animation_State(isAttacking);
        }
    }

    // اعمال آسیب به هدف
    public void Make_Damege()
    {
        if (currentTarget.GetComponent<Tower_Controler>() != null)
        {
            if (!currentTarget.GetComponent<Tower_Controler>().Get_Dameg(Dameg_Power))
            {
                currentTarget = null;
                Set_Animation_State(false);
                isAttacking = false;
            }
        }
        else
        {
            if (!currentTarget.GetComponent<Casel_Life_Controller>().Get_Dameg(Dameg_Power))
            {
                currentTarget = null;
                Set_Animation_State(false);
                isAttacking = false;
            }
        }
    }

    // دریافت آسیب
    public void Get_Dameg(GameObject ob)
    {
        Helf -= ob.GetComponent<Arrow_Controler>().Power;
        Life_Line.fillAmount = (Helf / 100);

        // بررسی نابودی دشمن
        if (Helf <= 0)
        {
            event_Holder.Rise(Price);
            Enemy_Sponer.spawnedEnemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    // هدف نابود شده
    public void TargetDestroyed()
    {
        currentTarget = null;
        isAttacking = false;
        Set_Animation_State(isAttacking);
    }

    // به روزرسانی وضعیت انیمیشن
    private void Set_Animation_State(bool isAttacking)
    {
        animator.SetBool("IsAttacking", isAttacking);
    }
}
