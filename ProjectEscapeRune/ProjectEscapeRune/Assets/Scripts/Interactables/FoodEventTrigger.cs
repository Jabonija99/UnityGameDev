using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEventTrigger : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private GameManagerController _gameManagerController;
    private ItemNotificationController _itemNotification;
    [SerializeField] private SphereCollider sphereCollider;

    void Start()
    {
        food.SetActive(true);
        _itemNotification = GetComponent<ItemNotificationController>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            food.SetActive(false);
            _gameManagerController.hasFood = true;
            _itemNotification.HandleNotification();
            sphereCollider.isTrigger = false;
            SoundManager.PlaySound(SoundType.ITEMGET);
            this.gameObject.SetActive(false);

        }
    }



}
