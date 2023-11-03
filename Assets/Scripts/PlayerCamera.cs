using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Variables and Components")]
    float clamper;
    [SerializeField] float mouseSens;
    [SerializeField] GameObject playerBody;
    bool torchIsOn;
    [SerializeField] Light torchLight;
    [SerializeField] Animator animator;
    [SerializeField] float blendTreeFloat;
    [SerializeField] PlayerStateMachine sm;
    [SerializeField] AudioSource torchAudioSource;
    [SerializeField] AudioClip torchUseSound;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (!torchIsOn)
        {
            torchLight.enabled = false;
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            torchIsOn = !torchIsOn;
            torchAudioSource.PlayOneShot(torchUseSound);

            if (torchIsOn)
            {
                torchLight.enabled = true;
            }
            else
            {
                torchLight.enabled = false;
            }
        }
    }

    private void Update()
    {
        MouseMover();
        animator.SetFloat("y", blendTreeFloat);

        SetBlendTreeLimits();
    }

    void SetBlendTreeLimits()
    {
        if (sm.currentState == sm.runState && sm.walkState.canRun)
        {
            if (blendTreeFloat < 1 && sm.walkState.canRun)
            {
                blendTreeFloat += Time.deltaTime;
            }
        }

        if (blendTreeFloat < 0)
        {
            blendTreeFloat = 0;
        }

        if (sm.currentState == sm.idleState)
        {
            if (blendTreeFloat > 0)
            {
                blendTreeFloat -= Time.deltaTime * 2;
            }
        }

        if (sm.currentState == sm.walkState && sm.lastState == sm.idleState)
        {
            if (blendTreeFloat < 0.5f)
            {
                blendTreeFloat += Time.deltaTime;
            }
        }

        if (sm.currentState == sm.walkState && sm.lastState == sm.runState)
        {
            if (blendTreeFloat > 0.5f)
            {
                blendTreeFloat -= Time.deltaTime;
            }
        }
    }

    private void MouseMover()
    {
        float yAxis = Input.GetAxis("Mouse Y") * mouseSens;
        float xAxis = Input.GetAxis("Mouse X") * mouseSens;

        clamper -= yAxis;
        clamper = Mathf.Clamp(clamper, -50f, 50f);

        transform.localRotation = Quaternion.Euler(clamper, 0, 0);

        playerBody.transform.Rotate(Vector3.up, xAxis);
    }
}