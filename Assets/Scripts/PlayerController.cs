using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera cam;
    private Rigidbody rb;
    private float forceToJump;
    public Gameover gameover;
    public float directionForce;
    private bool isJumping = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 10;
        forceToJump = 50;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forward.y = 0;
        right.y = 0;
        Vector3 forwardRelative = playerVerticalInput * forward;
        Vector3 rightRelative = playerHorizontalInput * right;

        Vector3 cameraRelativeMovement = forwardRelative + rightRelative;
        rb.AddForce(cameraRelativeMovement * directionForce);
        Debug.Log(cameraRelativeMovement);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector3(0, forceToJump, 0), ForceMode.Impulse);
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        if (collision.gameObject.tag == "Terrain")
        {
            gameover.GameIsOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("upsy");
    }
}