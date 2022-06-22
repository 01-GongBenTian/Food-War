using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame_UI : MonoBehaviour
{
    public Text Tomato_Number, Cream_Number, Basil_Number, Score;


    private void Awake()
    {
        //Set the text to the variable accordingly
        Tomato_Number = transform.Find("Tomato_Number").GetComponent<Text>();
        Cream_Number = transform.Find("Cream_Number").GetComponent<Text>();
        Basil_Number = transform.Find("Basil_Number").GetComponent<Text>();
        Score = transform.Find("Score").GetComponent<Text>();
    }


    // Start is called before the first frame update
    void Start()
    {
        //repeatedly invoke a method call "Update_UI" every 0.1s, without delay
        InvokeRepeating("Update_UI", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //method that update the UI during the game
    void Update_UI()
    {
        //update the number of item that player currently have
        Tomato_Number.text = "Tomato x " + Player_Condition.tomato;
        Cream_Number.text = "Cream x " + Player_Condition.cream;
        Basil_Number.text = "Basil x " + Player_Condition.basil;

        //update the score the player get in the game
        Score.text = "Score: " + GameManager.Score;
    }
}
