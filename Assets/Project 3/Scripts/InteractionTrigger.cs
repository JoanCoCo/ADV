using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject TargetObject;
    [SerializeField] private string VariableName;

    private void OnTriggerEnter(Collider other)
    {
        TargetObject.GetComponent<Animator>().SetBool(VariableName, true);
    }
}
