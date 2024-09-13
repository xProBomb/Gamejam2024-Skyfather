using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float playerSpeed = 1.0f;
    public Rigidbody2D playerRigidbody;
    private Vector2 moveInput;
    public GameObject playerBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        FaceMouse();
        FaceBody();
    }

    void Move()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        playerRigidbody.velocity = moveInput * playerSpeed;
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }

    void FaceBody()
    {
        playerBody.transform.position = transform.position;
        Vector3 initalRotation = transform.up;
        float angle = Mathf.Atan2(initalRotation.y, initalRotation.x) * Mathf.Rad2Deg;
        angle = SnapAngleToDirection(angle);
        playerBody.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    float SnapAngleToDirection(float angle)
    {
        if (angle >= -22.5f && angle < 22.5f)
        {
            return 0; // RIGHT
        }
        else if (angle >= 22.5f && angle < 67.5f)
        {
            return 45; // UP-RIGHT
        }
        else if (angle >= 67.5f && angle < 112.5f)
        {
            return 90; // UP
        }
        else if (angle >= 112.5f && angle < 157.5f)
        {
            return 135; // UP-LEFT
        }
        else if (angle >= 157.5f || angle < -157.5f)
        {
            return 180; // LEFT
        }
        else if (angle >= -157.5f && angle < -112.5f)
        {
            return 180; // DOWN-LEFT
        }
        else if (angle >= -112.5f && angle < -67.5f)
        {
            return -90; // DOWN
        }
        else if (angle >= -67.5f && angle < -22.5f)
        {
            return 0; // DOWN-RIGHT
        }
        return 0;
    }
}
