using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFlower : MonoBehaviour
{
    private Animator _anim;
    public bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(reset)
        {
            Debug.Log("Reset ON");
            _anim.SetBool("Reset", true);
            _anim.SetBool("Touched", false);
        } else
        {
            Debug.Log("Reset OFF");
            _anim.SetBool("Reset", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _anim.SetBool("Touched", true);
    }
}
