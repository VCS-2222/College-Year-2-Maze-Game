using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] AudioSource feetSource;
    [SerializeField] AudioClip footstepClip;

    public void UseFootstep()
    {
        feetSource.PlayOneShot(footstepClip);
    }
}