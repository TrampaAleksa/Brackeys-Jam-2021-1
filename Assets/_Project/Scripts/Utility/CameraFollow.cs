using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private Transform _cameraTransform;
    void Awake()
    {
        player = player == null ? GameObject.FindWithTag("Player").transform : player;
        _cameraTransform = _cameraTransform == null ? Camera.main.transform : _cameraTransform;
    }

    // Update is called once per frame
    void Update()
    {
        _cameraTransform.position = player.position + offset;
    }
}
