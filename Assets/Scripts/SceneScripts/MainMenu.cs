using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject LevelSelection;
    public void PlayGame()
    {
        LevelSelection.SetActive(true);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}