using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private void Update()
    {
        //for movement

        float Horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharacter(Horizontal);
        PlayMovementAnimation(Horizontal);
    }
    private void MoveCharacter(float Horizontal)
    {
        Vector3 position = transform.position;
        position.x += Horizontal * speed * Time.deltaTime;
        transform.position = position;
    }
    private void PlayMovementAnimation(float Horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));

        Vector3 scale = transform.localScale;
        if (Horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (Horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //For Jump Implementation

        float Jump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Jump", Mathf.Abs(Jump));

        if(Jump > 0) 
        {
          scale.x = Mathf.Abs(scale.x);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
          {
          animator.SetBool("Crouch", true);
          }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
         animator.SetBool("Crouch", false);
        }

        //Mayank sir video refrence code

        //Input.GetAxisRaw("Vertical");
        //Input.GetKeyDown(KeyCode.Space);
    }
}
