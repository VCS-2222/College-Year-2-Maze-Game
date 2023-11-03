using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFootsteps : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] AudioSource feetSource;
    [SerializeField] AudioClip footClip;
    public void UseFootstep()
    {
        feetSource.PlayOneShot(footClip);
    }
}