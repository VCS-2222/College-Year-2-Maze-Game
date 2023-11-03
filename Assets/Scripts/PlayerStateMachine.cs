using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IState
{
    public void UpdateState();
    public void FixedUpdateState();
    public void OnEnterState(PlayerStateMachine sm);
    public void OnExitState();
}

public class PlayerStateMachine : MonoBehaviour
{
    // attach this script to your player or enemy object that requires a state machine
    public IState currentState;
    public IState lastState;
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerWalkState walkState = new PlayerWalkState();
    public PlayerRunState runState = new PlayerRunState();
    public string state;

    private void Start()
    {
        lastState = null;
        walkState.canRun = true;
        // this is the inital state
        ChangeState(idleState);
    }

    public void Update()
    {
        state = currentState.ToString();

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

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }
        lastState = currentState;
        currentState = newState;
        currentState.OnEnterState(this);
    }


    public IState GetState()
    {
        return currentState;
    }
}