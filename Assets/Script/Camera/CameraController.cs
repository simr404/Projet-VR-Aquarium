using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform cam;

    public float speed = 8.0f;

    private CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection = new Vector3(cam.forward.x, cam.forward.y, cam.forward.z);
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);

        if (transform.position.y < 8) transform.position = new Vector3(transform.position.x, 8, transform.position.z);
    }
}
