using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DecisionController : MonoBehaviour
{
    [Header("Dialogue References")]
    [SerializeField] private GameObject currentDialogue;
    [SerializeField] private GameObject nextDialogue;

    [Header("Decision References")]
    [SerializeField] private GameObject allDecisions;
    [SerializeField] private GameObject decisionBoxReference;
    [SerializeField] private TextMeshProUGUI decisionText;

    [Header("Decision Settings")]
    public string optionText;



    private float disableAnimationDelay = 0.2f;

    private void Start()
    {
        decisionText.text = optionText;
    }

    private void OnEnable()
    {
        //Tween into scene
        
    }

    public void DecisionButtonActions()
    {
        //Enable Consequence
        ContinueDialogue();
    }

    private void ContinueDialogue()
    {
        StartCoroutine(DelayedDisable());

        currentDialogue.SetActive(false);
        nextDialogue.SetActive(true);
    }

    private IEnumerator DelayedDisable()
    {
        yield return new WaitForSeconds(disableAnimationDelay);
        allDecisions.SetActive(false);
    }
}
