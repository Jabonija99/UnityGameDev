using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyFollowRange : MonoBehaviour
{
    [SerializeField] private BabyController babyController;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) babyController.playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) babyController.playerInRange = false;
    }
}
