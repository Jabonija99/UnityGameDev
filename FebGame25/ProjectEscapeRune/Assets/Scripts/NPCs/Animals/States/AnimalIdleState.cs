using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalIdleState : AnimalBaseState
{
    private float timer;
    private bool isCompleted;


    public override void Enter()
    {
        isCompleted = false;
        timer = 0f;
        animalController.animalAnim.Play(animalController.animIdle);

    }

    public override void Exit()
    {

    }

    public override void FixedPerform()
    {
        
    }

    public override void Perform()
    {
        HandleWaitTimer();
        if (isCompleted)
        {
            animalStateMachine.ChangeState(new AnimalPatrolState());
        }
    }

    private void HandleWaitTimer()
    {
        if (timer < animalController.idleTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            isCompleted = true;
        }
    }

}
