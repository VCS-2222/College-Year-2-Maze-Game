using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterChaseState : MState
{
    MonsterStateMachine sm;
    NavMeshAgent agent;

    public void OnEnterState(MonsterStateMachine stateMachine)
    {
        sm = stateMachine;
        Debug.Log("MONSTER CHASE");
        agent = sm.transform.GetComponent<NavMeshAgent>();
    }

    public void UpdateState()
    {
        agent.destination = sm.player.transform.position;
    }

    public void FixedUpdateState()
    {
        
    }

    public void OnExitState()
    {
        
    }
}