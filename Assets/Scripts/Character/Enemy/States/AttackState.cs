using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    float moveTimer;
    float losePlayerTimer;
    float shotTimer;

    public override void Enter()
    {
    }

    public override void Perform()
    {
        if (enemy.HP <= 0) return;

        if (enemy.IsPlayerInSight())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;

            // stop moving and look at player
            enemy.Agent.isStopped = true;
            enemy.animator.SetBool("isShooting",true);
            enemy.transform.LookAt(enemy.Player.transform);

            if(shotTimer > enemy.fireRate)
            {
                Shoot();
            }

            if (moveTimer > 5)
            {
                enemy.Agent.SetDestination(enemy.transform.position + Random.insideUnitSphere );
                moveTimer = 0;
            }
        }
        else
        {
            enemy.Agent.isStopped = false;
            enemy.animator.SetBool("isShooting", false);
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 5)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public void Shoot()
    {
        

        // reference to gun barrel
        Transform gun = enemy.gun;

        // instantiate gun bullet
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/bullet") as GameObject, gun.position, enemy.transform.rotation);

        // calculate shoot direction
        Vector3 shootDirection = (enemy.hitPoint.transform.position - gun.transform.position).normalized;

        // add rigibody
        bullet.GetComponent<Rigidbody>().velocity =  shootDirection * 40;

        shotTimer = 0;
    }

    public override void Exit()
    {
    }



}
