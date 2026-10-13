using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEventTrigger : MonoBehaviour
{
    [SerializeField] private GameManagerController _gameManagerController;

    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject brokenWall;
    void Start()
    {
        wall.SetActive(false);
        brokenWall.SetActive(true);
        

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_gameManagerController.hasBricks == true)
            {
                wall.SetActive(true);
                _gameManagerController.hasFixedWall = true;
                SoundManager.PlaySound(SoundType.BRICKSOUND);
                brokenWall.SetActive(false);

            }
        }
            
    }
}
