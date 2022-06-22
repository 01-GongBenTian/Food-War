using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    Audio audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<Audio>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Start_New_Game()
    {
        audio.Play_One_Shot(audio.button_press);
        audio.Change_BGM(audio.game_bgm);

        PlayerManager.is_player_dead = false;
        GameManager.game_end = false;
        GameManager.Score = 0;

        SceneManager.LoadScene("Level 1");
    }

    public void Back_To_Menu()
    {
        audio.Play_One_Shot(audio.button_press);
        audio.Change_BGM(audio.menu_bgm);

        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        audio.Play_One_Shot(audio.button_press);

        Application.Quit();
    }

    public void Set_Active (GameObject gameobject)
    {
        audio.Play_One_Shot(audio.button_press);

        gameobject.SetActive(true);
    }


    public void Change_Scene(string scene_name)
    {
        audio.Play_One_Shot(audio.button_press);

        SceneManager.LoadScene(scene_name);
    }
}
