﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Unlocked:
               
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                FindObjectOfType<SoundManager>().Play("ButtonClick");
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}
