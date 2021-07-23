using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("Player Dead Script is Working");
    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is Dead");
        }
    }    
}
