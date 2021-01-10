﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private float lookSpeed;

    [SerializeField]
    private float yLimitTop;

    [SerializeField]
    private float yLimitBottom;

    private float rotationX;
    private float rotationY;

    private void Awake()
    {
        if (playerCamera == null) playerCamera = Camera.main;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;

        rotationY += Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, yLimitBottom, yLimitTop);

        updateCameraRotation();
        updatePlayerRotation();
    }

    void updateCameraRotation()
    {
        playerCamera.transform.localRotation = Quaternion.Euler(-rotationY, 0, 0);
    }

    void updatePlayerRotation()
    {
        transform.localRotation = Quaternion.Euler(0, rotationX, 0);
    }
}
