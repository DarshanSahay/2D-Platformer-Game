using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete));
        LostLife();
    }
    public void LostLife()
    {
        livesRemaining--;
        lives[livesRemaining].enabled = false;
        if (livesRemaining == 0)
        {
            Debug.Log("You Lost");
        }
    }
}
