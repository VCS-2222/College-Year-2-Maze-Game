using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerStaminaBar : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float maxCap;
    [SerializeField] float minCap;
    [SerializeField] float currentStamina;

    [Header("Components Needed")]
    [SerializeField] PlayerStateMachine sm;
    [SerializeField] Slider staminaSlider;

    private void Start()
    {
        currentStamina = maxCap;
        staminaSlider.maxValue = maxCap;
        staminaSlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        staminaSlider.value = currentStamina;

        if(sm.currentState == sm.runState)
        {
            staminaSlider.gameObject.SetActive(true);
            currentStamina--;
        }

        if(currentStamina <= minCap)
        {
            staminaSlider.gameObject.SetActive(false);
            sm.walkState.canRun = false;
        }
    }
}