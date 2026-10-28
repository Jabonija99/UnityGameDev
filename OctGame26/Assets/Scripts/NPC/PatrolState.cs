using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{

    private float waitTimer = 0f;
    public float waitTime;

    public int waypointIndex;
    

    public override void Enter() 
    {
        waitTimer = 0f;
    }

    public override void Perform() 
    {
        PatrolCycle();
    }

    public override void Exit() { }

    public void PatrolCycle()
    {
        if(npc.GetAgent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer > waitTime)
            {

                if (waypointIndex < npc.path.waypoints.Count - 1)
                {
                    waypointIndex++;
                }
                else
                {
                    waypointIndex = 0;
                }

                npc.GetAgent.SetDestination(npc.path.waypoints[waypointIndex].position);
                waitTimer = 0f;
            }
        }
    }
}
