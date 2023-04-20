using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMove : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;


    const string WALK = "Walk"; // ChangeAnimationState(WALK);
    const string IDLE = "Idle"; // ChangeAnimationState(IDLE);
    const string RUN = "Attack"; // ChangeAnimationState(RUN);
    private string currentState;

    public Transform target;

    public AudioClip[] footstepSounds; 
    public float footstepInterval = 0.5f; 
    private float footstepTimer;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        footstepTimer = 0f;
    }


    void Update()
    {

        if (transform.hasChanged)
        {
            animator.SetBool("IsMoving", true);
            transform.hasChanged = false;
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (animator.GetBool("IsMoving"))
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0f)
            {
                footstepTimer = footstepInterval;
                PlayFootstepSound();
            }
        }


        if (Vector3.Distance(transform.position, target.position) < 25)
        {
            animator.SetBool("IsChase", true);
            GetComponent<Pathfinding.AIPath>().SetSpeed(15);
        }



        if (Vector3.Distance(transform.position, target.position) < 4)
        {
            animator.SetBool("IsAttack", true);
        }

        if (Vector3.Distance(transform.position, target.position) > 4)
        {
            animator.SetBool("IsAttack", false);
        }
    }

    void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            int index = Random.Range(0, footstepSounds.Length);
            audioSource.PlayOneShot(footstepSounds[index], 10f);
        }
    }


    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }


}
