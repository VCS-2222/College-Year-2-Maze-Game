using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    PlayerStateMachine sm;
    CharacterController controller;

    float xAxis;
    float yAxis;

    Vector3 moveDirection;

    public void OnEnterState(PlayerStateMachine stateMachine)
    {
        sm = stateMachine;
        controller = sm.transform.GetComponent<CharacterController>();
    }

    public void UpdateState()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        moveDirection = yAxis * controller.transform.forward + xAxis * controller.transform.right;

        if(moveDirection.magnitude > 0)
        {
            sm.ChangeState(sm.walkState);
        }
    }

    public void FixedUpdateState()
    {

    }

    public void OnExitState()
    {

    }
}