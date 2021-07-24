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
        //if(Input.GetButtonDown("Jump"))
        //{
        //    GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        //}
        //for movement

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal,vertical);
        PlayMovementAnimation(horizontal,vertical);
    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //if(vertical >0)
        //{
        //    animator.SetBool("Jumping", true);
        //    rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        //}
        //else
        //{
        //    animator.SetBool("Jumping", false);
        //}
        animator.SetBool("Jumping", vertical>0);
        rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
    }
    private void PlayMovementAnimation(float horizontal,float vertical)
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
    }
}
