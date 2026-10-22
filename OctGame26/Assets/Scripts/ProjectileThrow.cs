using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrajectoryPredictor))]
public class ProjectileThrow : MonoBehaviour
{
    TrajectoryPredictor trajectoryPredictor;

    [SerializeField]
    GameObject objectToThrow;
    private Camera camera;

    [SerializeField, Range(0.0f, 50.0f)]
    private float force;

    [SerializeField]
    private Vector3 throwDirection = new Vector3(0, 1, 0);

    [SerializeField]
    private Transform startPosition;

    private bool canAim = false;

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
            Predict();
        }
    }

    private void OnEnable()
    {
        trajectoryPredictor = GetComponent<TrajectoryPredictor>();

        if (startPosition == null)
            startPosition = transform;
    }

    private void Predict()
    {
        trajectoryPredictor.PredictTrajectory(ProjectileData());
    }

    private ProjectileProperties ProjectileData()
    {
        ProjectileProperties properties = new ProjectileProperties();
        Rigidbody rb = objectToThrow.GetComponent<Rigidbody>();

        properties.direction = (camera.transform.forward + throwDirection).normalized;
        properties.initialPosition = startPosition.position;
        properties.initialSpeed = force;
        properties.mass = rb.mass;
        properties.drag = rb.drag;


        return properties;
    }

    public void ThrowObject()
    {
        Vector3 spawnPosition = startPosition.position + camera.transform.forward;

        GameObject candy = Instantiate(objectToThrow, spawnPosition, camera.transform.rotation);

        Rigidbody rb = candy.GetComponent<Rigidbody>();

        Vector3 finalThrowDirection = (camera.transform.forward + throwDirection).normalized; 

        rb.AddForce(finalThrowDirection * force, ForceMode.Impulse);
    }

    public void StartAim()
    {
        canAim = true;
    }

    public void StopAim() 
    {
        canAim = false;
    }
}
