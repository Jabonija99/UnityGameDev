using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    [SerializeField] public Image greenBar;
    [SerializeField] public Image redBar;
    [SerializeField] public Image backgroundBar;
    [SerializeField] public PlayerController player;
    private float playerMaxHealth;
    private float playerCurrentHealth;
    [SerializeField] public GameObject healthBarPosition;
    

    void Start()
    {

        
    }

    
    void Update()
    {
        Debug.Log("Check");
        playerMaxHealth = (float)player.playerMaxHealth;
        playerCurrentHealth = (float)player.playerCurrentHealth;
        float precent = playerCurrentHealth / playerMaxHealth;
        Debug.Log("Check 2" );
        Debug.Log(precent);

        greenBar.fillAmount = precent;
        TrackPlayer();
        

    }

    void TrackPlayer()
    {
        greenBar.transform.position = healthBarPosition.transform.position;
        redBar.transform.position = healthBarPosition.transform.position;
        backgroundBar.transform.position = healthBarPosition.transform.position;

    }
}
