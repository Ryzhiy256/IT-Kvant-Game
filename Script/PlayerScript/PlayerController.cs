using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject Camera;


    private float movementX;
    private float movementY;

    [Header("Характеристики игрока")]
    public float jumpForce;
    public float speed;
    public float sensitivy;


    private bool CheckContactGround = true;

    private bool CheckViewTarget = true;// True - Вид от третьего лица / False - Вид от первого лица
    [Header("Настройки для камеры")]
    public GameObject CameraThirdView;
    public GameObject CameraFirstView;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
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

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckContactGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            CheckContactGround = false;
        }

        if (Input.GetKeyDown(KeyCode.V)) 
        {
            if (CheckViewTarget) 
            {
                CameraFirstView.SetActive(true);
                CameraThirdView.SetActive(false);
                CheckViewTarget = false;
            }
            else
            {
                CameraFirstView.SetActive(false);
                CameraThirdView.SetActive(true);
                CheckViewTarget = true;
            }
        }



        if (CheckViewTarget)
        {
            if (movementX != 0 || movementY != 0)
            {
                PlayerRotation();
            }
        }
        else
        {
            PlayerRotation();
        }
    }

    public void PlayerRotation() 
    {
        Quaternion playerRotation = transform.rotation;
        Quaternion cameraRotation = Camera.transform.rotation;

        playerRotation.x = 0f;
        playerRotation.z = 0f;

        cameraRotation.x = 0f;
        cameraRotation.z = 0f;

        transform.rotation = Quaternion.Lerp(playerRotation, cameraRotation, Time.deltaTime * sensitivy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CheckContactGround = true;
        }
    }
}
