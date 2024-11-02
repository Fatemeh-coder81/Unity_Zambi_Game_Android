using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[Serializable]
public class info_Holder_For_Sound
{
    public Sprite Mute_Sound_sprite;
    public Sprite Open_Sound_sprite;
    public bool Sound_State;
    public Image Sound_Mute_Butten;
    public TextMeshProUGUI Sound_Mute_Text;

};
public class Menu : MonoBehaviour
{
    public GameObject Info_Panel;

    public GameObject Setting_Panel;

   public info_Holder_For_Sound info_Holder_For_Sound = new info_Holder_For_Sound();

    void Start()
    {
        info_Holder_For_Sound.Sound_Mute_Text.text = "Mute The Sound";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play_Game()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    public void Open_Info_Panel()
    {
        Info_Panel.SetActive(!Info_Panel.activeInHierarchy);
    }
    
    
    public void Open_Setting()
    {
        Setting_Panel.SetActive(!Setting_Panel.activeInHierarchy);
    }

    public void Mute_The_Sound()
    {
        if (info_Holder_For_Sound.Sound_State == true)
        {
            info_Holder_For_Sound.Sound_Mute_Text.text = " On Mute Sound";
            info_Holder_For_Sound.Sound_State = false;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            info_Holder_For_Sound.Sound_Mute_Butten.sprite = info_Holder_For_Sound.Mute_Sound_sprite;
           
        }
        else
        {
            info_Holder_For_Sound.Sound_Mute_Text.text = "Mute Sound";
            info_Holder_For_Sound.Sound_State = true;
            Camera.main.GetComponent<AudioListener>().enabled = true;
            info_Holder_For_Sound.Sound_Mute_Butten.sprite = info_Holder_For_Sound.Open_Sound_sprite;
        }
    }


}
