using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerInputs inputs;
    private bool willRotate = false;
    private float ySensitivity = 20f;

    // Start is called before the first frame update
    void Awake()
    {
        inputs = new PlayerInputs();
        inputs.Main.RotateCamera.performed += ctx => ProcessCameraRotation();
        inputs.Main.RotateCamera.canceled += ctx => StopCameraRotation();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if(willRotate)
            RotateCamera(inputs.Main.MousePosition.ReadValue<Vector2>());
    }

    private void RotateCamera(Vector2 input) 
    {
        Transform transform = this.gameObject.transform;
        
        if(input.x == 0)
        {
            return;
        }
        else if(input.x > 0)
        {
            transform.Rotate(0, (10 * Time.deltaTime) * ySensitivity, 0);
        }
        else if(input.x < 0)
        {
            transform.Rotate(0, (-10 * Time.deltaTime) * ySensitivity, 0);
        }
    }

    private void ProcessCameraRotation()
    {
        willRotate = true;
    }

    private void StopCameraRotation()
    {
        willRotate = false;
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
