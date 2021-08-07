using UnityEngine;


public class PlayerDead : MonoBehaviour
{
    
    public GameOverController gc;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gc.PlayerDied();
        }
    }    
}
