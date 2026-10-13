using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttackRange : MonoBehaviour
{
    [SerializeField] private DogController dogController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) dogController.playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) dogController.playerInRange = false;
    }

}
