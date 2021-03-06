using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFlower : MonoBehaviour
{
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _anim.SetBool("Touched", true);
    }
}
