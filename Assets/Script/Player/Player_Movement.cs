using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moving_speed, move_distance, rotate_speed;

    public Vector3 target_position;

    private Quaternion facing;

    // Start is called before the first frame update
    void Start()
    {
        target_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal_Movement();

        Vertical_Movement();

        rotation();
        
    }

    void Horizontal_Movement()
    {
        if(GameManager.horizontal_input != 0 && !PlayerManager.is_moving_along_z && !PlayerManager.is_player_dead && !GameManager.game_end)
        {
            PlayerManager.is_moving_along_x = true;

            if (transform.position == target_position)
            {
                target_position += new Vector3(GameManager.horizontal_input * move_distance, 0, 0);
            }
        }
        else
        {
            if (transform.position == target_position)
            {
                PlayerManager.is_moving_along_x = false;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target_position, moving_speed * Time.deltaTime);
    }

    void Vertical_Movement()
    {
        if (GameManager.vertical_input != 0 && !PlayerManager.is_moving_along_x && !PlayerManager.is_player_dead && !GameManager.game_end)
        {
            PlayerManager.is_moving_along_z = true;

            if(transform.position == target_position)
            {
                target_position += new Vector3(0, 0, GameManager.vertical_input * move_distance);
            }
        }
        else
        {
            if(transform.position == target_position)
            {
                PlayerManager.is_moving_along_z = false;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target_position, moving_speed * Time.deltaTime);
    }

    void rotation()
    {
        if(PlayerManager.is_moving_along_x)
        {
            if(GameManager.horizontal_input == 1)
            {
                facing = Quaternion.Euler(0, 90, 0);
            }
            else if(GameManager.horizontal_input == -1)
            {
                facing = Quaternion.Euler(0, 270, 0);
            }
        }
        else if(PlayerManager.is_moving_along_z)
        {
            if(GameManager.vertical_input == 1)
            {
                facing = Quaternion.Euler(0, 0, 0);
            }
            else if(GameManager.vertical_input == -1)
            {
                facing = Quaternion.Euler(0, 180, 0);
            }
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, facing, rotate_speed * Time.deltaTime);
    }
}
