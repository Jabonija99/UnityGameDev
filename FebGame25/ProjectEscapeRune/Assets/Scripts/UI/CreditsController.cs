using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private float fadeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        FadeIn();
    }

    private void OnEnable()
    {
        
    }

    private void FadeIn()
    {

        LeanTween.alphaCanvas(canvasGroup, 1f, fadeTime).setEase(LeanTweenType.easeInSine);
    }
}
