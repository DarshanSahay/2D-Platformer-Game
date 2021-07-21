using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private void Update()
    {
        //for movement

        float Speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(Speed));

        Vector3 scale = transform.localScale;
        if(Speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(Speed > 0)
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

    }
}
