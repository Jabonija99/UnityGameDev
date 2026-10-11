using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{

  
    [SerializeField] private GameObject _fire;
    [SerializeField] private GameObject _playerFire;
    [SerializeField] private GameObject _badEndDialogue;
    [SerializeField] private GameObject _goodEndDialogue;
    [SerializeField] private CanvasGroup _endCredits;
    [SerializeField] private CinemachineVirtualCamera _virtualCam;

    [SerializeField] private PlayerController _playerController;

    [SerializeField] private GameManagerController _gameManager;
    private bool soundHasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        _fire.SetActive(false);
        _playerFire.SetActive(false);
        _virtualCam.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InitEndSequence();
    }

    private void OnEnable()
    {
       
    }

    public void InitEndSequence()
    {
        _virtualCam.Priority = 12;
        _playerController.canMove = false;

        if(CheckIfQuestsCompleted())
        {
            GoodEndSequence();
        }
        else
        {
            StartCoroutine(BadEndSequence());
        }

        
    }

    private bool CheckIfQuestsCompleted()
    {
        bool isComplete = true;

        if(!_gameManager.hasKilledIntruder)
            isComplete = false;

        if(!_gameManager.hasFedDog)
            isComplete = false;

        if(!_gameManager.hasFixedWall)
            isComplete = false;

        return isComplete;


    }

    public IEnumerator BadEndSequence()
    {
        yield return new WaitForSeconds(2f);
        _fire.SetActive(true);

        if (!soundHasPlayed)
        {
            SoundManager.PlaySound(SoundType.EXPLOSION);
            soundHasPlayed = true;
        }
        
        yield return new WaitForSeconds(1f);
        _badEndDialogue.SetActive(true);
        yield return new WaitForSeconds(1f);
    }

    private void GoodEndSequence()
    {
        _goodEndDialogue.SetActive(true);
    }
}
