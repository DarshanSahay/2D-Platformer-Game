using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChomperController : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public PlayerController pc;
    public Animator anim;
    public Animator animator;
    
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    
    public int currentHealth = 100;
    public int maxHealth = 100;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                
                transform.eulerAngles = new Vector3(0, -180, 0);
                anim.SetBool("Walk", true);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Hurt", true);
            pc.TakeDamage(20);
        }

    }
    private void FixedUpdate()
    {
        animator.SetBool("Hurt", false);
    }
}
