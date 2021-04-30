using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject followingCamera;
    [SerializeField] private GameObject controlledCamera;
    [SerializeField] private KeyCode interactionKey = KeyCode.M;
    private bool isInControl = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(interactionKey))
        {
            isInControl = !isInControl;
            UpdateCamera();
        }
    }

    private void UpdateCamera()
    {
        if(isInControl)
        {
            followingCamera.SetActive(false);
            controlledCamera.SetActive(true);
        } else
        {
            controlledCamera.SetActive(false);
            followingCamera.SetActive(true);
        }
    }

    public Camera GetActiveCamera()
    {
        return isInControl ? controlledCamera.GetComponent<Camera>() : followingCamera.GetComponent<Camera>();
    }
}
