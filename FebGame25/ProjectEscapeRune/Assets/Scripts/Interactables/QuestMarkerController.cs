using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarkerController : MonoBehaviour
{
    [SerializeField] private GameObject _questMarker;
    private bool isActivated = false;

    [SerializeField] private LeanTweenType _easeType;
    [SerializeField] private float animationTime = 1.5f;
    [SerializeField] private float yPosition = -0.2f;

    // Start is called before the first frame update
    void Start()
    {
        _questMarker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
           
        }
    }


    private void AnimateMarker()
    {
        LeanTween.moveLocalY(_questMarker, yPosition, animationTime).setLoopPingPong().setEase(_easeType);
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            isActivated = true;
            _questMarker.SetActive(isActivated);
            //AnimateMarker();
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            isActivated = false;
            _questMarker.SetActive(isActivated);
        }
    }
}
