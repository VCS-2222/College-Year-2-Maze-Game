using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface MState
{
    public void UpdateState();
    public void FixedUpdateState();
    public void OnEnterState(MonsterStateMachine sm);
    public void OnExitState();
}

public class MonsterStateMachine : MonoBehaviour
{
    // attach this script to your player or enemy object that requires a state machine
    public MState currentState, lastState;
    public MonsterIdleState idleState = new MonsterIdleState();
    public MonsterChaseState chaseState = new MonsterChaseState();

    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        lastState = null;
        // this is the inital state
        ChangeState(idleState);
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedUpdateState();
        }
    }

    public void ChangeState(MState newState)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }
        lastState = currentState;
        currentState = newState;
        currentState.OnEnterState(this);
    }


    public MState GetState()
    {
        return currentState;
    }
}