using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speed;
    float xRot;
    float yRot;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        xRot -= Input.GetAxisRaw("Mouse Y")*speed;
        yRot += Input.GetAxisRaw("Mouse X")*speed;

        xRot = Mathf.Clamp(xRot, -90, 90);
    }

    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(xRot, yRot, 0);
    }
}
