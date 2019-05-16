using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private const string horizontal = "Horizontal";
    private bool isGrounded = true;
    private Animator ani;

    public float speed=10f;
    public float jumpSpeed=3000;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxis(horizontal) * speed, playerRb.velocity.y);
        if (Input.GetAxis(horizontal) == 0)
        {
            ani.SetBool("isWalking", false);
        }
        else
        {
            ani.SetBool("isWalking", true);
            if (Input.GetAxis(horizontal) < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            playerRb.AddForce(Vector2.up * jumpSpeed);
            isGrounded = false;
            ani.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
    }
}
