using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class CoolCharacterNavAI : MonoBehaviour
{
    //public Transform goal;
    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private Transform destinationMark;
    [SerializeField] private CameraManager cameraManager;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraManager.GetActiveCamera().ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.destination = destinationMark.position = hit.point;
            }
        }

        if (agent.isOnOffMeshLink) animator.SetTrigger("Jump");
        animator.SetFloat("XDir", transform.InverseTransformDirection(agent.velocity).x);
        animator.SetFloat("YDir", transform.InverseTransformDirection(agent.velocity).z);
    }
}
