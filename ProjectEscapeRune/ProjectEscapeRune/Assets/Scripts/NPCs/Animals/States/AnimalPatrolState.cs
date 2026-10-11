using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPatrolState : AnimalBaseState
{
    

    public override void Enter()
    {
        animalController.Agent.SetDestination(animalController.path.waypoints[animalController.waypointIndex].position);
        animalController.animalAnim.Play(animalController.animWalk);
    }

    public override void Exit()
    {
        if (animalController.waypointIndex < animalController.path.waypoints.Count - 1)
        {
            animalController.waypointIndex++;
        }
        else
        {
            animalController.waypointIndex = 0;
        }
    }

    public override void FixedPerform()
    {
        
    }

    public override void Perform()
    {
        Patrol();
    }

    private void PatrolCycle()
    {
        if(animalController.Agent.remainingDistance < 0.2f)
        {
            if(animalController.waypointIndex < animalController.path.waypoints.Count - 1)
            {
                animalController.waypointIndex++;
            }
            else
            {
                animalController.waypointIndex = 0;
            } 
        }
    }

    private void Patrol()
    {
        if (animalController.Agent.remainingDistance < 0.2f)
        {
            animalStateMachine.ChangeState(new AnimalIdleState());
        }
    }
}
