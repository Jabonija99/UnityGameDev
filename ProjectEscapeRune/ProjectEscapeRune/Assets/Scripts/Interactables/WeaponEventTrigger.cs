using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponEventTrigger : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameManagerController _gameManagerController;
    [SerializeField] private SphereCollider sphereCollider;

    private ItemNotificationController _itemNotification;
    private void Start()
    {
        weapon.SetActive(true);
        _itemNotification = GetComponent<ItemNotificationController>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            weapon.SetActive(false);
            _gameManagerController.hasWeapon = true;
            _itemNotification.HandleNotification();
            sphereCollider.isTrigger = false;
            SoundManager.PlaySound(SoundType.ITEMGET);
            this.gameObject.SetActive(false);
            
        }
    }


}
