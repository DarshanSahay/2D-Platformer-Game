using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log("Lets start");
    }

    private void OnCollisionEnter2D(Collision2D collision)

        {
            if (collision.gameObject.CompareTag("Finish"))
            {
                SceneManager.LoadScene(1);
                Debug.Log("Level Finished By the Player");
            }

            else if(collision.gameObject.CompareTag("Fall"))
           {
            Debug.Log("Player Fall Down , Plzz Restart");
            }
        }
    

}

