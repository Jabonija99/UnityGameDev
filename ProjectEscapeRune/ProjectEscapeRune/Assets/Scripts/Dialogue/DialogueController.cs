using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class DialogueController : MonoBehaviour
{
    

    [Header("Dialogue References")]
    [SerializeField] private GameObject _playerReference;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private string[] _lines;
    private int _index;
    private bool _hasStarted;

    [Header("Dialogue Settings")]
    public float textDelay;
    public bool isFirstDialogue;
    public bool isLastDialogue;
    [SerializeField] private GameObject[] _objectsToDisable;
    [SerializeField] private GameObject[] _objectsToEnable;
    private float _disableDelay = 0.2f;

    [Header("Decision Settings")]
    public bool hasDecisionEvent;
    [SerializeField] private GameObject _decisionEvent;


    // Start is called before the first frame update
    void Start()
    {
        //_hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_dialogueText.text == _lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                _dialogueText.text = _lines[_index];
            }
        }
    }

    private void OnEnable()
    {
        if (isFirstDialogue)
        {
            //_hasStarted = false;
            _playerReference.GetComponent<PlayerController>().isMoving = false;
            _playerReference.GetComponent<PlayerController>().canMove = false;
            _playerReference.GetComponent<NavMeshAgent>().enabled = false;
            //LeanTween Dialogue to size
        }
        else
        {
            //Set default dialogue size
        }

        StartDialogue();
    }


    private void StartDialogue()
    {
        _dialogueText.text = string.Empty;
        _index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach(char c in _lines[_index].ToCharArray())
        {
            _dialogueText.text += c;
            yield return new WaitForSeconds(textDelay);
        }
    }

    public void NextLine()
    {
        if(_index < _lines.Length - 1)
        {
            _index++;
            _dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if(!hasDecisionEvent)
            {
                if (isLastDialogue)
                {
                    StartCoroutine(DisableDialogueDelayed());
                    _playerReference.GetComponent<PlayerController>().canMove = true;
                    _playerReference.GetComponent<NavMeshAgent>().enabled = true;
                }
                else
                {
                    DisableDialogueImmediately();
                }
            }
            else
            {
                if(_decisionEvent != null)
                {
                    _decisionEvent.SetActive(true);
                }
                else
                {
                    Debug.Log("Decision Event missing from dialogue controller!");
                }
            }
        }
    }


    private void DisableDialogueImmediately()
    {
        gameObject.SetActive(false);

        if(_objectsToDisable != null)
        {
            foreach (var obj in _objectsToDisable)
            {
                obj.SetActive(false);
            }
        }

        if (_objectsToEnable != null)
        {
            foreach (var obj in _objectsToEnable)
            {
                obj.SetActive(true);
            }
        }
    }

    private IEnumerator DisableDialogueDelayed()
    {
        yield return new WaitForSeconds(_disableDelay);

        gameObject.SetActive(false);

        if (_objectsToDisable != null)
        {
            foreach (var obj in _objectsToDisable)
            {
                obj.SetActive(false);
            }
        }

        if (_objectsToEnable != null)
        {
            foreach (var obj in _objectsToEnable)
            {
                obj.SetActive(true);
            }
        }
    }
}
