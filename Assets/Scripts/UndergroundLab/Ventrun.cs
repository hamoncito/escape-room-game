using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventrun : MonoBehaviour
{
    [SerializeField] private AudioClip metalPunch;
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.enabled = true;
            animator.Play("run");
            audioSource.Play();
        }
    }

    public void EndRun()
    {
        audioSource.clip = metalPunch;
        audioSource.Play();
    }
}
