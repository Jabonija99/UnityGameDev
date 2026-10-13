using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyNearDoor : MonoBehaviour
{

    [SerializeField] private BabyController babyController;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Baby"))
        {
            babyController.TransformBaby();
            SoundManager.PlaySound(SoundType.BONES);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

}
