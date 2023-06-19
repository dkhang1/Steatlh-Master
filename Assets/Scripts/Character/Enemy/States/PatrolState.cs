using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int wayPointIndex = 0;
    public float waitTimer;
   
    public override void Enter()
    {

    }

    public override void Perform()
    {
        PatrolCycle();
        if (enemy.IsPlayerInSight())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }

    public override void Exit()
    {

    }

    public void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            enemy.animator.SetBool("isPatrolling", false);
            if (waitTimer > 3)
            {

                if (wayPointIndex < enemy.path.wayPoints.Count - 1)
                {
                    wayPointIndex++;
                }
                else
                {
                    wayPointIndex = 0;
                }
                waitTimer = 0;
                enemy.Agent.SetDestination(enemy.path.wayPoints[wayPointIndex].position);
                enemy.animator.SetBool("isPatrolling", true);
            }
        }
    }
}
