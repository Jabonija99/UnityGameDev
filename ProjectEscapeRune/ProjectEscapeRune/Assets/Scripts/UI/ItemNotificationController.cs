using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNotificationController : MonoBehaviour
{

    [Header("Notification References")]
    public ItemData itemReference;
    [SerializeField] private GameObject _notificationUI;

    public void HandleNotification()
    {
        if(_notificationUI != null)
        {
            _notificationUI.GetComponent<NotificationController>().Reset();
            _notificationUI.SetActive(false);
            _notificationUI.GetComponent<NotificationController>().SetItem(itemReference);
            _notificationUI.SetActive(true);
        }
        else
        {
            Debug.Log("Notification UI not found!");
        }

    }
}
