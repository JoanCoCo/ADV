using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class CharacterGravity : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private float gravity = 0.01f;
    [SerializeField] private float step = 0.01f;
    [SerializeField] private float maxGravity = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion Tree"))
        {
            Debug.Log("Applying smooth gravity");
            controller.Move(Vector3.down * gravity * Time.deltaTime);
            if(gravity > maxGravity) gravity += step;
        }
    }
}
