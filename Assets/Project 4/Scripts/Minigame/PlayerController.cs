using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float jump = 2.0f;
    private float xInput = 0.0f;
    private float yInput = 0.0f;
    private enum State { On, Off };
    [SerializeField] private State state = State.Off;
    private float currVel = 0.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (state == State.On)
        {
            //controller.Move(Vector3.down * gravity * Time.deltaTime);
            yInput = Input.GetAxisRaw("Vertical");
            xInput = Input.GetAxis("Horizontal");

            if (Mathf.Approximately(yInput, 0.0f))
            {
                animator.SetFloat("XDir", xInput);
            }
            else
            {
                transform.Rotate(Vector3.up, 90.0f * Time.deltaTime * xInput);
                float xdir = animator.GetFloat("XDir");
                if (Mathf.Abs(xdir) > 0.0f)
                {
                    animator.SetFloat("XDir", xdir - Mathf.Sign(xdir) * 0.05f);
                }
            }

            animator.SetFloat("YDir", Mathf.SmoothDamp(animator.GetFloat("YDir"), yInput, ref currVel, 0.3f));
        } else
        {
            animator.SetFloat("YDir", 0);
            animator.SetFloat("XDir", 0);
        }
    }

    public void StartMiniGame()
    {
        state = State.On;
    }
}
