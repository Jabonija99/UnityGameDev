using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    //Seriialized for debugging
    [SerializeField]
    private string currentState;
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public Path path;

    public NavMeshAgent GetAgent { get => agent; }

    private GameObject player;
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialize();
        player = GameManager.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            //If the player is close enough to be seen
            if(Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - Vector3.up * eyeHeight;
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                if(angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();

                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }
        }

        Debug.Log("Player Not Found!");
        return false;
    }
}
