using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    private void Awake()
    {
        restartButton.onClick.AddListener(RestartLevel);
    }
    
    [SerializeField] public string sceneName;
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void RestartLevel()
    {
     SceneManager.LoadScene(sceneName);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
