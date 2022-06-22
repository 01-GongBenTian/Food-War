using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Condition : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedmeshrenderer;

    private Animator animator;

    public GameObject Model;

    public Material red_tomato, white_cream, green_basil, normal_colour;

    public static int tomato, cream, basil;

    public static string condition;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        skinnedmeshrenderer = Model.GetComponent<SkinnedMeshRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        condition = "Normal";

        tomato = 0;
        cream = 0;
        basil = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.is_player_dead)
        {
            detect_of_using_item();

            change_material();
        }
    }


    void detect_of_using_item()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && tomato > 0)
        {
            tomato--;

            Check_and_Given_Back_Item();

            condition = "Red";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && cream > 0)
        {
            cream--;

            Check_and_Given_Back_Item();

            condition = "White";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && basil > 0)
        {
            basil--;

            Check_and_Given_Back_Item();

            condition = "Green";
        }

        if(Input.GetKeyDown(KeyCode.Alpha0) && condition != "Normal")
        {
            Check_and_Given_Back_Item();

            condition = "Normal";
        }
    }



    void change_material()
    {
        switch(condition)
        {
            case "Red":
                {
                    skinnedmeshrenderer.material = red_tomato;
                    break;
                }
            case "White":
                {
                    skinnedmeshrenderer.material = white_cream;
                    break;
                }
            case "Green":
                {
                    skinnedmeshrenderer.material = green_basil;
                    break;
                }
            default:
                {
                    skinnedmeshrenderer.material = normal_colour;
                    break;
                }

        }
    }



    void Check_and_Given_Back_Item()
    {
        if(condition != "Normal")
        {
            switch (condition)
            {
                case "Red":
                    {
                        tomato++;
                        break;
                    }
                case "White":
                    {
                        cream++;
                        break;
                    }
                case "Green":
                    {
                        basil++;
                        break;
                    }
            }
        }
    }
}
