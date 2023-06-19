using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    float moveTimer;
    float losePlayerTimer;


    public override void Enter()
    {
    }

    public override void Perform()
    {
        if (enemy.IsPlayerInSight())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            if (moveTimer > (Random.Range(3, 7) * 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + Random.insideUnitSphere);
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 5)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public void Shoot()
    {

    }

    public override void Exit()
    {
    }



}
