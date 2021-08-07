using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    private Rigidbody2D rb2d;
    public string sceneName;
    public GameOverController gc;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    float horizontalvalue;
    [SerializeField] bool isgrounded;
    [SerializeField] public float jumpPower;
    [SerializeField] bool jump;
    //public Transform groundDetection;
    [SerializeField] const float groundCheckRadius = 0.2f;
    public AudioSource set;

    private void Awake()
    {
        set.Play();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        horizontalvalue = Input.GetAxisRaw("Horizontal");
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = false;
            animator.SetBool("Jump", false);
        }
        animator.SetFloat("Yvelocity", rb2d.velocity.y);
    }
    private void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalvalue,jump);
        PlayMovementAnimation(horizontalvalue);
        jump = false;
    }
    void GroundCheck()
    {
        isgrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        //RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (colliders.Length > 0)
            isgrounded = true;
        animator.SetBool("Jump", !isgrounded);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            KillPlayer();
        }
    }
    public void KillPlayer()
    {
        animator.SetBool("Death", true);
        set.Stop();
        gc.PlayerDied();
        this.enabled = false;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void PickUpKey()
    {
        Debug.Log("Player Picked Up the Key");
        scoreController.IncreaseScore(10);
    }
    private void Move(float horizontalvalue, bool jumpflag)
    {
        Vector3 position = transform.position;
        position.x += horizontalvalue * speed * Time.deltaTime;
        transform.position = position;
        if (isgrounded && jumpflag)
        {
            jumpflag = false;
            rb2d.AddForce(new Vector2(0f, jumpPower));
        }
    }
    private void PlayMovementAnimation(float horizontalvalue)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalvalue));

        Vector3 scale = transform.localScale;
        if (horizontalvalue < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontalvalue > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (Input.GetKey(KeyCode.LeftControl))
          {
          animator.SetBool("Crouch", true);
          }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
         animator.SetBool("Crouch", false);
        }
    }
}
