﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public Sound[] sounds;
    private static Dictionary<string, float> soundTimerDictionary;

    public static SoundManager instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        soundTimerDictionary = new Dictionary<string, float>();

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.isLoop;

            if (sound.hasCooldown)
            {
                Debug.Log(sound.name);
                soundTimerDictionary[sound.name] = 0f;
            }
        }
    }

  
    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound == null)
        {
            Debug.LogError("Sound " + name + " Not Found!");
            return;
        }

        if (!CanPlaySound(sound)) return;

        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound == null)
        {
            Debug.LogError("Sound " + name + " Not Found!");
            return;
        }

        sound.source.Stop();
    }

    private static bool CanPlaySound(Sound sound)
    {
        if (soundTimerDictionary.ContainsKey(sound.name))
        {
            float lastTimePlayed = soundTimerDictionary[sound.name];

            if (lastTimePlayed + sound.clip.length < Time.time)
            {
                soundTimerDictionary[sound.name] = Time.time;
                return true;
            }

            return false;
        }

        return true;
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SoundManager : MonoBehaviour
//{
//    private static SoundManager instance;
//    public static SoundManager Instance { get { return instance; } }
//    public AudioSource soundEffect;
//    public AudioSource soundMusic;
//    public SoundType[] Sounds;
//    private void Awake()
//    {
//     if(instance == null)
//        {
//            instance = null;
//            DontDestroyOnLoad(gameObject);
//        }
//     else
//        {
//            Destroy(gameObject);
//        }
//    }
//    public void Play(Sounds sound)
//    {
//        AudioClip clip = getSoundClip(sound);
//        if(clip != null)
//        {
//            soundEffect.PlayOneShot(clip);
//        }
//        else
//        {
//            Debug.LogError("clip not found for sound type : " + sound);
//        }
//    }
//    private AudioClip getSoundClip(Sounds sound)
//    {
//        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
//        if(item != null)
//        return item.soundClip;
//        return null;
//    }
//    [SerializeField]public class SoundType
//    {
//        public Sounds soundType;
//        public AudioClip soundClip;
//    }
    public enum Sounds
    {
        ButtonClick,
        PlayerMove,
        PlayerDeath,
        EnemyDeath,
    }
//}
