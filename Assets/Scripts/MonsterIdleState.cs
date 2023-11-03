using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdleState : MState
{
    MonsterStateMachine sm;

    float timer;
    float tillChaseTimer = 10;

    public void OnEnterState(MonsterStateMachine stateMachine)
    {
        sm = stateMachine;
        Debug.Log("MONSTER IDLE");

        timer = tillChaseTimer;
    }

    public void UpdateState()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer < 0)
        {
            sm.ChangeState(sm.chaseState);
        }
    }

    public void FixedUpdateState()
    {

    }

    public void OnExitState()
    {
        
    }
}