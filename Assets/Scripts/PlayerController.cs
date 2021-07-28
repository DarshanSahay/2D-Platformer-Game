using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject MyObject;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
       
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal,vertical);
        PlayMovementAnimation(horizontal,vertical);
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void PickUpKey()
    {
        Debug.Log("Player Picked Up the Key");
        scoreController.IncreaseScore(10);
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

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
