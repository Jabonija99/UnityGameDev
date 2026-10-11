using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStateMachine : MonoBehaviour
{
    public AnimalBaseState activeState;

    public void Initialize()
    {
        ChangeState(new AnimalIdleState());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null) 
            activeState.Perform();
    }

    private void FixedUpdate()
    {
        if (activeState != null)
            activeState.FixedPerform();
    }

    public void ChangeState(AnimalBaseState newState)
    {
        if(activeState != null)
        {
            activeState.Exit();
        }

        activeState = newState;

        if(activeState != null)
        {
            activeState.animalStateMachine = this;
            activeState.animalController = GetComponent<AnimalController>();
            activeState.Enter();
        }
    }
}
