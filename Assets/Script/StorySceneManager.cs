using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySceneManager : MonoBehaviour
{
    public DialogSystem dialogSystem;
    public Button_Script button_Script;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the dialog of the story end start the game from the start
        if(dialogSystem.dialog_end)
        {
            // invoke the method in "button_Script" which perform a function that start a new game from the start
            button_Script.Start_New_Game();
        }    
    }
}
