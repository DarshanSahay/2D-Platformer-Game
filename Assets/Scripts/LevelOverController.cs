using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    [SerializeField] private string levelname;
    private void Awake()
    {
        Debug.Log("Lets start");
    }

    private void OnCollisionEnter2D(Collision2D collision)

        {
            Debug.Log("Collision 2D is working");

            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(1);
                Debug.Log("Level Finished By the Player");
            }

        }
    

}

