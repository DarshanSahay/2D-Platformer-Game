using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    [SerializeField] private string scenename;

    private void OnCollisionEnter2D(Collision2D collision)

        {
            //Debug.Log("Collision 2D is working");

            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(scenename);
                Debug.Log("Level Finished By the Player");
            }

        }
    

}

