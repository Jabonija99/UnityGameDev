using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedEnable : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;

    private void OnEnable()
    {
        StartCoroutine(DelayEnable());
    }

    private IEnumerator DelayEnable()
    {
        yield return new WaitForSeconds(0.1f);
        objectToEnable.SetActive(true);
    }
}
