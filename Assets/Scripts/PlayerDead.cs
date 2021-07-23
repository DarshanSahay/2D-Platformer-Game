using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("Player Dead Script is Working");
    }
    private void OnTriggerEnter2D (Collider2D collision)

    {
        if(collision.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Player is Dead");
        }
    }    
}
