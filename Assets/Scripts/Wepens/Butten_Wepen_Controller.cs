using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Video.VideoPlayer;


[Serializable]
public class UI_OutPut
{
    public Image Wepen_Image;

    public TextMeshProUGUI Price_Text;
};

public class Butten_Wepen_Controller : MonoBehaviour
{

    public UI_OutPut UI_OutPut = new UI_OutPut();

    public int Wepen_Id;


    public Event_Holder eventHandler;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Palce_The_Tower()
    {
        eventHandler.Rise( Wepen_Id);

       
    }

}
