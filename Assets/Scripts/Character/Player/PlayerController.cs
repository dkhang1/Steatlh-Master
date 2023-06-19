using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private Vector2 move;
    [SerializeField] public Animator animator;
    [SerializeField] public int damageAmount = 20;
   

    private int HP = 100;

    public Slider heathBar;


    private void Start()
    {
       
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void Movement()

    {
        if (move.x != 0 || move.y != 0)
        {
            animator.SetBool("isRunning", true);
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        else{
            animator.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        heathBar.value = HP;



        Movement();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(damageAmount);
            animator.SetTrigger("Slash");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isSlashing", false);

    }

   
}

