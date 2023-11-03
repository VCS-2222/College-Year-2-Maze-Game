using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomDeathScreen : MonoBehaviour
{
    [SerializeField] string[] deathSentances;
    [SerializeField] TextMeshProUGUI deathMessage;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        int ranInt = Random.Range(0, deathSentances.Length);
        deathMessage.text = deathSentances[ranInt];
    }
}