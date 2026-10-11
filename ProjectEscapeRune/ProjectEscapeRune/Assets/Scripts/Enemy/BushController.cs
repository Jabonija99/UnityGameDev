using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BushController : MonoBehaviour
{
    [SerializeField] private GameObject _playerReference;
    private NavMeshAgent _agent;
    public bool cameraInRange = false;

    [SerializeField] private GameObject _invaderPrefab;
    private GameObject invaderInstance;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CheckCamera();
        MoveBush();
    }

    private void MoveBush()
    {
        if (!cameraInRange)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_playerReference.gameObject.transform.position);
        }
        else
        {
            _agent.isStopped = true;
        }
    }

    private void CheckCamera()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(this.gameObject.transform.position);

        if (screenPosition.x >= -.25f &&
            screenPosition.x <= 1.25f &&
            screenPosition.y >= -.25f &&
            screenPosition.y <= 1.25f)
        {
            cameraInRange = true;
        }
        else
        {
            cameraInRange = false;
        }
    }

    private void SpawnInvader()
    {
        invaderInstance = Instantiate(_invaderPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnInvader();
        }
    }
}
