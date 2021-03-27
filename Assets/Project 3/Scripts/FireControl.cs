using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    [SerializeField] private GameObject[] fireSources;
    private Animator[] sourceAnimators;

    public float speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        sourceAnimators = new Animator[fireSources.Length];
        for (int i = 0; i < fireSources.Length; i++)
        {
            sourceAnimators[i] = fireSources[i].GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var source in sourceAnimators)
        {
            source.SetFloat("Speed", speed);
        }
    }
}
