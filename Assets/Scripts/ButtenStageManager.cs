using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtenStageManager : MonoBehaviour
{
    public int LevelNumber = 1;
   
    public GameObject Lock_Icon;

    public StageManager StageManager;

    public bool State = false;

    // چک می‌کند که آیا مرحله باز است یا قفل
    public void IsStageUnlocked()
    {
        // اگر در PlayerPrefs ذخیره نشده، آن را ایجاد و قفل می‌کند
        if (!PlayerPrefs.HasKey("Stage_" + LevelNumber))
        {
            PlayerPrefs.SetInt("Stage_" + LevelNumber, 0); // قفل است

        }

    }



    
    void Start()
    {
        IsStageUnlocked();

        if ( StageManager.CheckStageStatus(LevelNumber) == "Open")
        {
            Lock_Icon.SetActive(false);
            State = true;
        }
    }


    public void OnPeress()
    {

        if(State)
        {
            SceneManager.LoadScene(("Level " + LevelNumber));
        }

    }



}
