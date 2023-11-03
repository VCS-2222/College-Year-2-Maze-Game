using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimatorController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] MonsterStateMachine sm;
    [SerializeField] Animator animator;
    [SerializeField] float flowOfTreeBlend;

    private void Update()
    {
        animator.SetFloat("y", flowOfTreeBlend);

        if (sm.currentState == sm.chaseState)
        {
            if(flowOfTreeBlend < 1)
            {
                flowOfTreeBlend += Time.deltaTime;
            }
        }

        if(sm.currentState == sm.idleState) 
        {
            if(flowOfTreeBlend > 0)
            {
                flowOfTreeBlend -= Time.deltaTime * 5;
            }
        }
    }
}