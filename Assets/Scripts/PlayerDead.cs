using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(sceneName);
            Debug.Log("Player is Dead");  
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Chomper Killed Player");
        }
    }    
}
