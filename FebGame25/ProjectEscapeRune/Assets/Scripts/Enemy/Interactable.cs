using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType {Enemy, Item}

public class Interactable : MonoBehaviour
{
    public EnemyController enemyController { get; private set; }
   //public Agent myAgent { get; private set; }

    public InteractableType interactionType;

    private void Awake()
    {
        if (interactionType == InteractableType.Enemy)
        {
            enemyController = GetComponent<EnemyController>();

        }
    }

    public void InteractWithItem()
    {
        Destroy(gameObject);
    }

}
