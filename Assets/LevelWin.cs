using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelWin : MonoBehaviour
{
    public AudioSource st;
    public GameObject levelWin;
    private PlayerController pt;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelWin.SetActive(true);
            st.Play();
        }
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

}
