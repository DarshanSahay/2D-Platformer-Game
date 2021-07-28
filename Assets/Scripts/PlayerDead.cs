using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    public PlayerController pc;
    private void Awake()
    {
      pc.TakeDamage(20);
    }
    [SerializeField] private string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)

    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);

            Debug.Log("Player is Dead");  
        }
        
    }    
}
