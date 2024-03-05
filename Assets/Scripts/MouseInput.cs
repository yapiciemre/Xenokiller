using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Transform player;
    public float mouseSens = 200f;
    private float xRotation;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXPos = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseYPos = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        player.Rotate(Vector3.up * mouseXPos);

        xRotation -= mouseYPos;
        xRotation = Mathf.Clamp(xRotation, -85f, +85f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        

    }
}
