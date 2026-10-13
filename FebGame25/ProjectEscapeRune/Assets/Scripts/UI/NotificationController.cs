using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationController : MonoBehaviour
{
    [Header("Animation Settings")]
    public float startYPosition;
    public float endYPosition;
    public float animationTime;
    public float fadeTime;
    public float notificationTime;

    [Header("References")]
    [SerializeField] private CanvasGroup notificationUI;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;

    public void SetItem(ItemData item)
    {
        icon.sprite = item.icon;
        itemName.text = item.displayName;
    }

    private void OnEnable()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, startYPosition);
        notificationUI.alpha = 0f;
        LeanTween.moveLocalY(this.gameObject, endYPosition, animationTime).setEase(LeanTweenType.easeOutBack);
        LeanTween.alphaCanvas(notificationUI, 1, fadeTime);
        StartCoroutine(DelayedDisable());
    }

    private void OnDisable()
    {
        Reset();
    }

    public void Reset()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, startYPosition);
        notificationUI.alpha = 0f;
        StopAllCoroutines();
        LeanTween.cancelAll(notificationUI);
        LeanTween.cancelAll(this.gameObject);
    }

    private IEnumerator DelayedDisable()
    {
        yield return new WaitForSeconds(notificationTime);
        LeanTween.alphaCanvas(notificationUI, 0, fadeTime);
        yield return new WaitForSeconds(animationTime);
        this.gameObject.SetActive(false);
    }
}
