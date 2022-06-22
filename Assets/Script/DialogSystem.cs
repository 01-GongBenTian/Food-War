using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogSystem : MonoBehaviour
{
    public Text content_diaplay;
    public GameObject dialog_box;

    public TextAsset dialog;
    List<string> dialog_list = new List<string>();

    string[] list_of_dialog;

    bool display_end = false;
    public bool dialog_end = false;

    public int dialog_index;

    Audio audio;


    // Start is called before the first frame update
    void Start()
    {
        // set variable "audio" as the "Audio" script that attach to gameobject with tag "AudioSource"
        audio = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<Audio>();

        // split the dialog text file content whenever there is a '\n' and store the splited content to a array call "list_of_dialog"
        list_of_dialog = dialog.text.Split('\n');

        // add each of member in "list_of_dialog" array to a list call "dialog_list"
        foreach (string dialog in list_of_dialog)
        {
            dialog_list.Add(dialog);
        }

        // start to display the first dialog in the "dialog_list", character by character
        StartCoroutine(Display_Dialog());
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player had press down left button of the mouse
        if(Input.GetMouseButtonDown(0))
        {

            if (dialog_index < dialog_list.Count && display_end)// if the current dialog had display completely and there is a dialog that need to be display after current dialog
            {
                // play the sound effect of pressing down button
                audio.Play_One_Shot(audio.button_press);

                //start to display the next dialog;
                StartCoroutine(Display_Dialog());
            }
            else if(display_end && dialog_index >= dialog_list.Count && dialog_end == false)// if the current dialog had display completely and there is no dialog that need to be display after current dialog
            {
                // play the sound effect of pressing down button
                audio.Play_One_Shot(audio.button_press);

                // end this dialog
                Close_Dialog_System();
            }

        }
    }


    // method that display dialog character by character
    IEnumerator Display_Dialog()
    {
        // set the bool that check is the display of the dialog finish or not to false
        display_end = false;

        // clear the text display in dialog box
        content_diaplay.text = "";

        // a loop that add every character in the dialog that currently display according to index
        foreach (char character in list_of_dialog[dialog_index])
        {
            content_diaplay.text += character;

            // wait for every 0.05s to start a new loop
            yield return new WaitForSeconds(0.05f);
        }

        // plus one to the variable that record the index of the dialog going to display next
        dialog_index++;

        // set the bool that check is the display of the dialog finish or not to true
        display_end = true;
    }


    // a method that close the dialog system 
    void Close_Dialog_System()
    {
        dialog_end = true;

        dialog_box.SetActive(false);

        StartCoroutine(Disappearing());

        if(SceneManager.GetActiveScene().name == "GameWin")
        {
            audio.Play_One_Shot(audio.game_win);
        }
        else if(SceneManager.GetActiveScene().name == "GameLose")
        {
            audio.Play_One_Shot(audio.game_lose);
        }
    }


    // a method that slowly disappear the background
    IEnumerator Disappearing()
    {
        while (gameObject.GetComponent<Image>().color.a > 0)
        {
            gameObject.GetComponent<Image>().color -= new Color(0, 0, 0, 0.05f);

            yield return new WaitForSeconds(0.05f);
        }

        gameObject.SetActive(false);
    }
}
