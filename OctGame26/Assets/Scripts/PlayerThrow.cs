using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [SerializeField]
    private GameObject candyLurePrefab;
    private Camera camera;

    [Header("Throwing Variables")]
    [SerializeField] 
    private float throwForce = 10f;
    [SerializeField] 
    private Vector3 throwDirection = new Vector3(0, 1, 0);
    [SerializeField] 
    private Transform startPosition;

    [Header("Aiming Variables")]
    private bool canAim = false;
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    [Range(10, 100)]
    private int linePoints = 25;
    [SerializeField]
    [Range(0.01f, 0.25f)]
    private float timeBetweenPoints = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAim)
        {
            ProcessAim();
        }
        else
        {
            StopAim();
        }
    }

    public void ProcessThrow()
    {
        Vector3 spawnPosition = startPosition.position + camera.transform.forward;

        GameObject candyLure = Instantiate(candyLurePrefab, spawnPosition, camera.transform.rotation);

        Rigidbody rb = candyLure.GetComponent<Rigidbody>();

        Vector3 finalThrowDirection = (camera.transform.forward + throwDirection).normalized;
;
        rb.AddForce(finalThrowDirection * throwForce, ForceMode.VelocityChange);
    }


    public void ProcessAim()
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt(linePoints / timeBetweenPoints + 1);
        Vector3 releasePosition = startPosition.position; 
        Vector3 startVelocity = throwForce * (camera.transform.forward + throwDirection);
        int i = 0;
        lineRenderer.SetPosition(i, releasePosition);
        for(float time = 0; time < linePoints; time += timeBetweenPoints)
        {
            i++;
            Vector3 point = releasePosition + time * startVelocity;
            point.y = releasePosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);
            lineRenderer.SetPosition(i, point);
        }
    }

    public void StartAim()
    {
        canAim = true;
    }

    public void StopAim()
    {
        canAim = false;
        lineRenderer.enabled = false;
    }
}
