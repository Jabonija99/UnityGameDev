using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private GameObject _firstDialogue;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Start Dialogue
            _dialogueBox.SetActive(true);
            _firstDialogue.SetActive(true);
        }
    }
}
