using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip menu_bgm, game_bgm, button_press, attack, game_lose, game_win;

    // Start is called before the first frame update
    void Start()
    {
        // if there is multiple "AudioSource" object, left one and destroy other
        if(GameObject.FindGameObjectsWithTag("AudioSource").Length > 1)
        {
            Destroy(gameObject);
        }

        // set the variable "audioSource" as the AudioSource component of the gameobject that this script attached to
        audioSource = GetComponent<AudioSource>();
        
        // don't destroy this GameObject when changing the scene
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // a method which use to play a audioClip once only (play a sound effect)
    public void Play_One_Shot(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }


    // a method use to change the BGM that playing in the game
    public void Change_BGM(AudioClip BGM)
    {
        audioSource.clip = BGM;
        audioSource.Play();
    }

    public void Stop_BGM()
    {
        audioSource.Stop();
    }
}
