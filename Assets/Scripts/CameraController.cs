using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

   
    [SerializeField] float speed;

    float xRot;
    float yRot;

    Ray RayOrigin;
    RaycastHit HitInfo;

    bool lockView;
    GameObject targetObject;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        lockView = false;
    }
    void Update()
    {

        if (!lockView)
        {
            xRot -= Input.GetAxisRaw("Mouse Y") * speed;
            yRot += Input.GetAxisRaw("Mouse X") * speed;
            xRot = Mathf.Clamp(xRot, -90, 90);
        }

        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, 100.0f))
        {
            if (HitInfo.transform.gameObject.tag == "Interactable")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (lockView)
                    {
                        lockView = false;
                    }
                    else
                    {
                        lockView = true;
                        targetObject = HitInfo.transform.gameObject;
                    }
                }
            }
        }
    }

    void LateUpdate()
    {
        if (!lockView)
        {
            transform.eulerAngles = new Vector3(xRot, yRot, 0);
        }
        else
        {
            SmoothLookAt(targetObject.transform.position - transform.position);
            xRot = transform.eulerAngles.x;
            yRot = transform.eulerAngles.y;
        }
    }

    void SmoothLookAt(Vector3 newDirection)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime*10);
    }

}
