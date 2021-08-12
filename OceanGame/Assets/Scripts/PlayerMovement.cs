using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform surfaceCheck;
    public LayerMask surfaceLayer;

    float horizontal;
    float vertical;
    float speed = 4f;
    public float gravity = 4f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        if (transform.position.y > -0.5)
        {
            rb.velocity = new Vector2(rb.velocity.x, -gravity);
        }
    }

    private bool IsSurfaced()
    {
        return Physics2D.OverlapCircle(surfaceCheck.position, 0.2f, surfaceLayer);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }
}
