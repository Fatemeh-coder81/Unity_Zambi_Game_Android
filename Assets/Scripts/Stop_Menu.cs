using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stop_Menu : MonoBehaviour
{
    
    void Start()
    {
        Time.timeScale = 1;
    }

   
    void Update()
    {
        
    }


    public void Stop_Game()
    {
        Time.timeScale = 0;
    }


    public void On_Stop()
    {
        Time.timeScale = 1;
    }

    public void Reset_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Go_Home()
    {
        SceneManager.LoadScene("Home");
    }
}
