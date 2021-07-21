using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //for movement

        float horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharacter(horizontal,vertical);
        PlayMovementAnimation(horizontal,vertical);
    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if(vertical >0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }
    private void PlayMovementAnimation(float horizontal, float vertical)//adding vertical is showing error
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //For Jump Implementation (WORKING)

        //float Jump = Input.GetAxisRaw("Vertical");
        //animator.SetFloat("Jump", Mathf.Abs(Jump));

        //if(Jump > 0) 
        //{
          //scale.x = Mathf.Abs(scale.x);
        //}

        if (Input.GetKeyDown(KeyCode.LeftControl))
          {
          animator.SetBool("Crouch", true);
          }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
         animator.SetBool("Crouch", false);
        }

        //Mayank sir video refrence code (NOT WORKING)

        float vertical = Input.GetAxisRaw("Jump");
        if(vertical >0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
