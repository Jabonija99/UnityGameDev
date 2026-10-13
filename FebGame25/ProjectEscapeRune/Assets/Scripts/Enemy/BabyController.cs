using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BabyController : MonoBehaviour
{

    [SerializeField] private GameObject _prefabSkele;
    private GameObject skeleInstance;

    private NavMeshAgent babyAgent;
    [SerializeField] private GameObject player;
    public bool playerInRange = false;
    public bool babyEvilNow = true;


    private void Start()
    {
        babyAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (!playerInRange)
        {FollowTarget();}
        else
        {
            babyAgent.isStopped=true;
        }

       
        
    }


    public void TransformBaby() 
    {
        skeleInstance = Instantiate(_prefabSkele, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }

    private void FollowTarget()
    {
        babyAgent.isStopped = false;
        babyAgent.SetDestination(player.transform.position);
        
    }
   

}
