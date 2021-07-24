using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    [SerializeField]GameObject gameObject;
    [SerializeField] private string sceneName;
    //public void Start()
    //{
    //    Debug.Log("Player Dead Script is Working");
    //}
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject);
            SceneManager.LoadScene(sceneName);
            Debug.Log("Player is Dead");
           
        }
    }    
}
