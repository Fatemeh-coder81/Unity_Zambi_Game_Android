using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casel_Life_Controller : MonoBehaviour
{
    public float Casel_Life = 1000f;

    public Event_Holder Event_Holder;


    public GameObject Ferst_Canvas;
    public GameObject Win_Loss_Canvas;

    public GameObject Loss_Panel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public bool Get_Dameg(float Dameg_Power)
    {
        Casel_Life -= Dameg_Power;
        if (Casel_Life <= 0)
        {
            Time.timeScale = 0;
            Ferst_Canvas.SetActive(false);
            Win_Loss_Canvas.SetActive(true);
            Loss_Panel.SetActive(true);

            return false;
        }
        Event_Holder.Rise(Casel_Life);
        return true;
    }

    public void Updata_Ui()
    {
        Event_Holder.Rise(Casel_Life);
    }
}
