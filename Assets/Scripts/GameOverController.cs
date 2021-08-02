using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverController : MonoBehaviour
{
    [SerializeField] public string sceneName;
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void RestartLevel()
    {
        
         SceneManager.LoadScene(sceneName);
         Time.timeScale = 1f;
    }
    
}
