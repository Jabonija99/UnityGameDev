using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{

    [SerializeField] private EnemyController enemyController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) enemyController.playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) enemyController.playerInRange = false;
    }


}
