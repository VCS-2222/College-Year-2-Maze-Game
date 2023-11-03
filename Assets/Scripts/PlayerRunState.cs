using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerRunState : IState
{
    PlayerStateMachine sm;
    CharacterController controller;
    float speed = 0.15f;

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
        if (!sm.walkState.canRun)
        {
            sm.ChangeState(sm.walkState);
        }

        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        moveDirection = yAxis * controller.transform.forward + xAxis * controller.transform.right;
        Debug.Log(moveDirection.magnitude.ToString());

        if(moveDirection.magnitude > speed)
        {
            if (Input.GetKeyUp(KeyCode.LeftShift) && moveDirection.magnitude == 0)
            {
                sm.ChangeState(sm.idleState);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                sm.ChangeState(sm.walkState);
            }
        }
        else
        {
            sm.ChangeState(sm.walkState);
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