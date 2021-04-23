using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class CoolCharacterController : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    [SerializeField] private float gravity = 9.8f;
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

        if(Input.GetKey(KeyCode.I))
        {
            yInput = Mathf.MoveTowards(yInput, 1.0f, 1.5f * Time.deltaTime);
        } else if(Input.GetKey(KeyCode.M))
        {
            yInput = Mathf.MoveTowards(yInput, -1.0f, 1.5f * Time.deltaTime);
        } else
        {
            yInput = Mathf.MoveTowards(yInput, 0.0f, 1.5f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.K))
        {
            xInput = Mathf.MoveTowards(xInput, 1.0f, 1.5f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            xInput = Mathf.MoveTowards(xInput, -1.0f, 1.5f * Time.deltaTime);
        } else
        {
            xInput = Mathf.MoveTowards(xInput, 0.0f, 1.5f * Time.deltaTime);
        }

        animator.SetFloat("XDir", xInput);
        animator.SetFloat("YDir", yInput);
    }
}
