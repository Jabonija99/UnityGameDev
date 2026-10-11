using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    public bool hasBricks = false;
    public bool hasFixedWall = false;
    public bool hasFixedFence = false;
    public bool hasKilledIntruder = false;
    public bool hasFood = false;
    public bool hasFedDog = false;
    public bool hasWeapon = false;


    void Start()
    {
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        
    }

    

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
