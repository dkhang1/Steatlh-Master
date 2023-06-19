using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public int HP = 1;
    [SerializeField] public Animator animator;
    


    public void TakeDamage(int damageAmount)
    {
        HP = -damageAmount;
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
