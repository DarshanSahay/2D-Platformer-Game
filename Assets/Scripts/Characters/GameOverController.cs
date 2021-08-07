using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    [SerializeField] public string sceneName;
    public AudioSource sd;
    public void PlayerDied()
    {
        gameObject.SetActive(true);
        sd.Play();
    }
    public void RestartLevel()
    {        
         SceneManager.LoadScene(sceneName);
         Time.timeScale = 1f;
    }
    public void RestartLevel2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void RestartLevel3()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
    
}
