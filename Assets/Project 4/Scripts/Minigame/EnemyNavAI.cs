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
        agent.destination = destinationMark.position;
    }

    private void Update()
    {
        if (state == State.On && director.state != PlayState.Playing)
        {
            if (agent.isStopped) agent.isStopped = false;
            if (agent.isOnOffMeshLink) animator.SetTrigger("Jump");
            animator.SetFloat("XDir", transform.InverseTransformDirection(agent.velocity).x);
            animator.SetFloat("YDir", transform.InverseTransformDirection(agent.velocity).z);
        } else
        {
            if (!agent.isStopped) agent.isStopped = true;
        }
    }
}
