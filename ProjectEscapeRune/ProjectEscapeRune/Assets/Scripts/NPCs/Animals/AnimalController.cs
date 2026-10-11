using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalController : MonoBehaviour
{
    private AnimalStateMachine _stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }

    [SerializeField] private string currentState;

    public Path path;
    public int waypointIndex;

    public Animator animalAnim;
    public string animIdle;
    public string animWalk;
    public float idleTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        _stateMachine = GetComponent<AnimalStateMachine>();
        _stateMachine.Initialize();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = _stateMachine.activeState.ToString();
    }
}
