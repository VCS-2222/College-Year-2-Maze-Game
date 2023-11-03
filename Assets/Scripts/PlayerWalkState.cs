using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : IState
{
    PlayerStateMachine sm;
    CharacterController controller;
    float speed = 0.05f;
    public bool canRun;

    float xAxis;
    float yAxis;

    Vector3 moveDirection;

    public void OnEnterState(PlayerStateMachine stateMachine)
    {
        sm = stateMachine;
        controller = sm.GetComponent<CharacterController>();
    }

    public void UpdateState()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        moveDirection = yAxis * controller.transform.forward + xAxis * controller.transform.right;
        Debug.Log(moveDirection.magnitude.ToString());

        if (Input.GetKeyDown(KeyCode.LeftShift) && canRun && moveDirection.magnitude > 0)
        {
            sm.ChangeState(sm.runState);
        }

        if(moveDirection.magnitude == 0)
        {
            sm.ChangeState(sm.idleState);
        }
    }

    public void FixedUpdateState()
    {
        controller.Move(moveDirection * speed);
    }

    public void OnExitState()
    {

    }
}