using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogEventTrigger : MonoBehaviour
{


    
    [SerializeField] private GameObject dog;
    [SerializeField] private GameManagerController gameManagerController;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!gameManagerController.hasFedDog)
            {
                dog.gameObject.GetComponent<DogController>().dogFollow = true;
                SoundManager.PlaySound(SoundType.DOGGROWL);
            }

            Destroy(this.gameObject);
        }
            
     

    }

    

}
