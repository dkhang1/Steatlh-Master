using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    

    public void Initialise()
    {
        // setup trang thai mac dinh
        ChangeState(new PatrolState());
    }

    

    // Update is called once per frame
    void Update()
    {
       if(activeState != null)
        {
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (activeState != null)
        {
            // Xoa trang thai cu
            activeState.Exit();
        }
        // Doi trang thai
        activeState = newState;

        // Kiem tra trang thai moi k Null
        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
