using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float speed = 5;
    public int facingDirection = 1;

    public Rigidbody2D rb;
    public Animator anim;

    // Fixedupdate is called 50x frame
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0)
        {
            FlipPlayer();
        }

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        rb.velocity = new Vector2(horizontal, vertical) * speed;
    }

    void FlipPlayer()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
