using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;

    private NavMeshAgent agent;

    private GameObject player;

    public Animator animator;

    public NavMeshAgent Agent { get => agent; }

    public GameObject Player { get => player; }

    public GameObject hitPoint;


    public int HP;

    [SerializeField] private string currentState;

    public Path path;


    [Header("Hitbox values")]
    public float sightDistance = 10f;
    public float fieldOfView = 70f;
    public float eyesHeight;

    [Header("GunBarrel")]
    public Transform gun;
    [Range(0.1f, 10f)]
    public float fireRate;


    private void Start()
    {
        HP = 10;
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        hitPoint = GameObject.FindGameObjectWithTag("HitPoint");
    }

    private void FixedUpdate()
    {
        IsPlayerInSight();
        currentState = stateMachine.activeState.ToString();
    }

    public bool IsPlayerInSight()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyesHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyesHeight), targetDirection);
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
        return false;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            Invoke("DieAnimation", 0.8f);

        }
    }

    private void DieAnimation()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 1.5f);
    }
}
