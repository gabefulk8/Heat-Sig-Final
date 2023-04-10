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

    public float speed = 3f;

    private Vector3 previousPosition;
    private float elapsedTime;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        previousPosition = transform.position;
        elapsedTime = 0f;

    }


    void Update()
    {
        elapsedTime += Time.deltaTime;
        Vector3 currentPosition = transform.position;
        Vector3 displacement = currentPosition - previousPosition;
        float velocity = displacement.magnitude / elapsedTime;
        Debug.Log("Velocity: " + velocity);

        if (velocity > speed)
            {
                animator.SetBool("IsMoving", true);

            }
            else

            {
                animator.SetBool("IsMoving", false);

                previousPosition = currentPosition;
                elapsedTime = 0f;
            }




       // if (Vector3.Distance(transform.position, box.position) > 3)
      //  {
      //      animator.SetBool("IsMoving", true);
      //  }
      //  else
       // {
       //     animator.SetBool("IsMoving", false);
       // }


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
