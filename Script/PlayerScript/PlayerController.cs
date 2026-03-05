using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject Camera;
    public GameObject FreeLookCamera;

    private float movementX;
    private float movementY;
    public float jumpForce;

    public float speed;
    private float rotationSpeed = 10f;


    private bool CheckContactGround = true;




    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movement = movementValue.Get<Vector2>();

        movementX = movement.x;
        movementY = movement.y;
    }

    private void FixedUpdate()
    {
        Vector3 CameraForward = Camera.transform.forward; 
        Vector3 CameraRight = Camera.transform.right;  

        CameraForward.y = 0f;
        CameraRight.y = 0f;

        CameraForward.Normalize();
        CameraRight.Normalize();

        Vector3 movement = (CameraRight * movementX + CameraForward * movementY).normalized;
        movement *= speed;
        movement.y = rb.linearVelocity.y;
        rb.linearVelocity = movement;


    }

    public float sensitivy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckContactGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            CheckContactGround = false;
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivy;

        transform.Rotate(new Vector3(0, Camera.transform.eulerAngles.y * Time.deltaTime, 0));
        //Camera.transform.Rotate(new Vector3(0, mouseX, 0));
        //FreeLookCamera.GetComponent<CinemachineOrbitalFollow>().HorizontalAxis.Value = mouseX;

        //Debug.Log($"Данные с окружности {FreeLookCamera.GetComponent<CinemachineOrbitalFollow>().HorizontalAxis.Value}" +
        //$"Данные с Камеры {Camera.transform.eulerAngles.y} Данные с игрока {transform.eulerAngles.y}");

        if (movementX != 0 || movementY != 0) 
        {
            //float CameraYaw = Camera.transform.eulerAngles.y;
            //Quaternion targetRotation = Quaternion.Euler(0, CameraYaw, 0);
            //transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);


        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CheckContactGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FailTag")) 
        {
            transform.position = new Vector3(0, 2.276f, -25.00607f);
        }
    }
}
