using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float jump = 2.0f;
    private float xInput = 0.0f;
    private float yInput = 0.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {   

        controller.Move(Vector3.down * gravity * Time.deltaTime);
        yInput = Input.GetAxis("Vertical");
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

        animator.SetFloat("YDir", yInput);
    }
}
