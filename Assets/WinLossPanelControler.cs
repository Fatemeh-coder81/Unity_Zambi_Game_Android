using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinLossPanelControler : MonoBehaviour
{


    public int LevelNumber = 1;

    public AudioSource AudioSource;

    public AudioClip WinClip;
    public AudioClip LossClip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void  OK_Butten_ON_Press()
    {
        LevelNumber += 1;
        PlayerPrefs.SetInt("Stage_" + LevelNumber, 1);
        SceneManager.LoadScene("Level " + LevelNumber.ToString() );
    }

    public void Reset_Butten_ON_Press()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomePage_Butten_ON_Press()
    {
        SceneManager.LoadScene("Home");
    }



}
