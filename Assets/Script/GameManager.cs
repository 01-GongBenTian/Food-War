using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int horizontal_input, vertical_input;

    public static int Score, current_score;

    public static bool game_end;

    // Start is called before the first frame update
    void Start()
    {
        current_score = 0;
        game_end = false;
    }

    private void FixedUpdate()
    {
        horizontal_input = (int)Input.GetAxisRaw("Horizontal");
        vertical_input = (int)Input.GetAxisRaw("Vertical");


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            restart_level();
        }
    }



    void restart_level()
    {
        Score -= current_score;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
