using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyNavAI : MonoBehaviour
{
    //public Transform goal;
    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private Transform destinationMark;
    private enum State { On, Off };
    [SerializeField] private PlayableDirector director;
    [SerializeField] private State state = State.Off;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //agent.destination = destinationMark.position;
    }

    private void Update()
    {
        if (state == State.On)
        {
            agent.destination = destinationMark.position;
            Debug.Log("Running!!");
            if (agent.isStopped) {
                agent.isStopped = false;
            }
            animator.SetFloat("XDir", transform.InverseTransformDirection(agent.velocity).x);
            animator.SetFloat("YDir", transform.InverseTransformDirection(agent.velocity).z);
        } else
        {
            Debug.Log("Not running.");
            if (!agent.isStopped) agent.isStopped = true;
            animator.SetFloat("XDir", 0);
            animator.SetFloat("YDir", 0);
        }
    }
}
