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
    private float xInput = 0;
    private float yInput = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        controller.Move(Vector3.down * gravity * Time.deltaTime);

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        animator.SetFloat("XDir", xInput);
        animator.SetFloat("YDir", yInput);
    }
}
