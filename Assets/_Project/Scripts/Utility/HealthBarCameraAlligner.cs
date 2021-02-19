using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarCameraAlligner : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void AlignCamera() {
            var camXform = mainCamera.transform;
            var forward = transform.position - camXform.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXform.right);
            transform.rotation = Quaternion.LookRotation(forward, up);
    }

    private void Update()
    {
        AlignCamera();
    }
}
