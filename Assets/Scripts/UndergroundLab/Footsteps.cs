using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] footSteps;
    [SerializeField] private KeyCode[] moveKeys;

    private bool isPlayingSound;
    private int lastStepId;

    private void Update()
    {
        foreach (KeyCode moveKey in moveKeys)
        {
            if (Input.GetKey(moveKey))
            {
                if (isPlayingSound == false)
                {
                    isPlayingSound = true;
                    int stepId;

                    do
                    {
                        stepId = UnityEngine.Random.Range(0, footSteps.Length);
                    } while (stepId == lastStepId);

                    audioSource.clip = footSteps[stepId];
                    audioSource.Play();

                    Invoke(nameof(EnableSound), 0.75f);
                }
            }
        }
    }

    private void EnableSound()
    {
        isPlayingSound = false;
    }
}
