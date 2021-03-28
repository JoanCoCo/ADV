using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalEmitter : MonoBehaviour
{
    [SerializeField] private GameObject[] target;
    [SerializeField] private string[] keys;
    private Animator[] targetAnimators;

    public bool trigger = false;

    // Start is called before the first frame update
    void Start()
    {
        targetAnimators = new Animator[target.Length];
        for (int i = 0; i < target.Length; i++)
        {
            targetAnimators[i] = target[i].GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < target.Length; i++)
        {
            targetAnimators[i].SetBool(keys[i], trigger);
        }
    }
}
