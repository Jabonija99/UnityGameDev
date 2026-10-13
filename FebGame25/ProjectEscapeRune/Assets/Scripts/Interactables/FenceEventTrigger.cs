using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceEventTrigger : MonoBehaviour
{
   
    [SerializeField] private GameObject brokenFence;
    [SerializeField] private GameObject fixedFence;
    [SerializeField] private GameObject bush;
    [SerializeField] private GameManagerController _gameManagerController;
    [SerializeField] private GameObject fenceDialogue;

    private void Start()
    {
        brokenFence.SetActive(true);
        fixedFence.SetActive(false);
        bush.SetActive(false);
        fenceDialogue.SetActive(false);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            fenceDialogue.SetActive(true);
            brokenFence.SetActive(false);
            fixedFence.SetActive(true);
            bush.SetActive(true);
            _gameManagerController.hasFixedFence = true;
            SoundManager.PlaySound(SoundType.FENCESOUND);
            this.gameObject.SetActive(false);

        }
    }

}
