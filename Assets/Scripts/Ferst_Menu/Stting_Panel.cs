using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this for Slider

public class Setting_Panel : MonoBehaviour
{
    public AudioSource backgroundAudio; 
    public Slider volumeSlider;
  

    private const string VolumePrefKey = "BackgroundVolume";

    void Start()
    {
      
        if (PlayerPrefs.HasKey(VolumePrefKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey);
            backgroundAudio.volume = savedVolume;
            volumeSlider.value = savedVolume;
         
        }
        else
        {
            
            backgroundAudio.volume = 0.127f;
            volumeSlider.value = 0.127f;
          
        }

        // Add a listener to the slider to handle volume changes
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
    }

   public void OnVolumeChange(float value)
    {
        
        backgroundAudio.volume = value;

     

        PlayerPrefs.SetFloat(VolumePrefKey, value);
     
        PlayerPrefs.Save();
    }


    public bool Sound_State = true;

    public void Sound_Togel()
    {
        Sound_State = !Sound_State;

        switch(Sound_State)
        {
            case true:
                {
                    Camera.main.gameObject.GetComponent<AudioListener>().enabled = true;
                    break;
                }
            case false:
                {
                    Camera.main.gameObject.GetComponent<AudioListener>().enabled = false;
                    break;
                }
        }

    }

}
