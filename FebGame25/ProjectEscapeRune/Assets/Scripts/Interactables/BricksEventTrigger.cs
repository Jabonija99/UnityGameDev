using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksEventTrigger : MonoBehaviour
{
    [SerializeField] private GameManagerController _gameManagerController;

    [SerializeField] private GameObject bricks;

    private ItemNotificationController _itemNotification;
    void Start()
    {
        bricks.SetActive(true);
       _itemNotification = GetComponent<ItemNotificationController>();
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bricks.SetActive(false);
            _gameManagerController.hasBricks = true;
            _itemNotification.HandleNotification();
            SoundManager.PlaySound(SoundType.ITEMGET,1f);
            this.gameObject.SetActive(false);
           
        }
    }

}
