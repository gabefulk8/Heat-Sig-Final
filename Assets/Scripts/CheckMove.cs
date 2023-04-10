using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMove : MonoBehaviour
{
    private Animator animator;

    const string WALK = "Walk"; // ChangeAnimationState(WALK);
    const string IDLE = "Idle"; // ChangeAnimationState(IDLE);
    const string RUN = "Attack"; // ChangeAnimationState(RUN);
    private string currentState;

    public Transform target;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
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


        if (Vector3.Distance(transform.position, target.position) < 24)
        {
            animator.SetBool("IsChase", true);
            GetComponent<Pathfinding.AIPath>().SetSpeed(11);
        }



        if (Vector3.Distance(transform.position, target.position) < 5)
        {
            animator.SetBool("IsAttack", true);
        }

        if (Vector3.Distance(transform.position, target.position) > 5)
        {
            animator.SetBool("IsAttack", false);
        }
    }


    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }


}
