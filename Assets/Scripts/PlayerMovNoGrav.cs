using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovNoGrav : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator WaterAnimator;

    void Start()
    {
        rb.gravityScale = 0;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //setting up animation
        WaterAnimator.SetBool("Underwater", true);
        WaterAnimator.SetFloat("Horizontal", movement.x);
        WaterAnimator.SetFloat("Vertical", movement.y);
        WaterAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
