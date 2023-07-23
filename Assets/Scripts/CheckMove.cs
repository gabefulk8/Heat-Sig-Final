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
    public AudioClip[] runningFootstepSounds;
    public AudioClip[] scream;

    public float footstepInterval = 0.01f; 
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
                if (!animator.GetBool("IsChase"))
                {
                    PlayFootstepSound();
                }
                else if (!audioSource.isPlaying)
                {
                    PlayRunningFootstepSound();
                    PlayScream();
                }
            }
        }



        if (Vector3.Distance(transform.position, target.position) < 25)
        {
            animator.SetBool("IsChase", true);
            GetComponent<Pathfinding.AIPath>().SetSpeed(16);
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
        if (footstepSounds.Length > 0 && !audioSource.isPlaying)
        {
            int index = Random.Range(0, footstepSounds.Length);
            audioSource.PlayOneShot(footstepSounds[index], 1f);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                audioSource.Pause();
            }
        }

        
    }

    void PlayRunningFootstepSound()
    {
        if (runningFootstepSounds.Length > 0 && !audioSource.isPlaying)
        {
            int index = Random.Range(0, runningFootstepSounds.Length);
            audioSource.PlayOneShot(runningFootstepSounds[index], 13f);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                audioSource.Pause();
            }
        }


    }

    public void PlayScream()
    {
        int index = Random.Range(0, scream.Length);
        audioSource.clip = scream[index];
        audioSource.volume = 15f;
        audioSource.Play();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.Pause();
        }
    }




    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }







}
