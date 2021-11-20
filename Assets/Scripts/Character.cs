using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rb;

    public bool jumping = false;
    public bool jumpCompleted = false;
    public bool isDead = false;
    public float speed = 10f;
    public float jumpHeight;

    Vector2 _mouseAbsolute;
    Vector2 _smoothMouse;

    public Vector2 clampInDegrees = new Vector2(360, 180);
    public bool lockCursor;
    public Vector2 sensitivity = new Vector2(2, 2);
    public Vector2 smoothing = new Vector2(3, 3);
    public Vector2 targetDirection;
    public Vector2 targetCharacterDirection;

    public Vector3 jumpLocation;
    void Start()
    {
        jumpHeight = 3;
        speed = 5f;
        rb = GetComponent<Rigidbody>();

        lockCursor = true;
        targetDirection = transform.localRotation.eulerAngles;
        targetCharacterDirection = gameObject.transform.localRotation.eulerAngles;
    }

    
    void Update()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        var targetOrientation = Quaternion.Euler(targetDirection);
        var targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);

        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

        _smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
        _smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

        _mouseAbsolute += _smoothMouse;

        if (clampInDegrees.x < 360)
            _mouseAbsolute.x = Mathf.Clamp(_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);

        if (clampInDegrees.y < 360)
            _mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);

        transform.localRotation = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation * Vector3.right) * targetOrientation;

        var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, Vector3.up);
        gameObject.transform.localRotation = yRotation * targetCharacterOrientation;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed, ForceMode.Force); // * Time.deltaTime);
            //gameObject.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * speed, ForceMode.Force); // * Time.deltaTime);
            //gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed, ForceMode.Force); // * Time.deltaTime);
            //gameObject.transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
        rb.AddForce(transform.right * speed, ForceMode.Force); // * Time.deltaTime);
            //gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (jumping == false)
        {

            if (Input.GetKey("space"))
            {
                //jumping = true;

                if (jumpLocation == Vector3.zero) { jumpLocation = gameObject.transform.position; }

                rb.AddForce(Vector3.up * speed);
                if (gameObject.transform.position.y >= jumpHeight)
                {
                    jumping = true;
                }

            }
        }
        else if (jumping == true)
        {
            if (gameObject.transform.position.y <= jumpLocation.y + 0.1) 
            {
                jumpLocation = Vector3.zero;
                jumping = false;
            }
        }

    }
}
