using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovWithGrav : MonoBehaviour
{

    public float moveSpeed = 5f;

    public float jumpForce = 5f;

    public Rigidbody2D rb;

    public float ymovement;

    public Animator LandAnimator;

    void Start()
    {
        rb.gravityScale = 2;
        rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
    }

    void Update()
    {
        //checking if gravity still works. If not, fix it.
        if (rb.gravityScale == 2)
        {
            Debug.Log("Gravity On");
        } else
        {
            rb.gravityScale = 2;
        }
         
        Jump();
        Vector3 xmovement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += xmovement * Time.deltaTime * moveSpeed;

        //setting up animation
        LandAnimator.SetBool("Underwater", false);
        LandAnimator.SetFloat("Horizontal", xmovement.x);
        LandAnimator.SetFloat("Vertical", ymovement);
        LandAnimator.SetFloat("Speed", xmovement.sqrMagnitude);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            ymovement = 1f;
        } else if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            ymovement = 0f;
        }
    }
}
