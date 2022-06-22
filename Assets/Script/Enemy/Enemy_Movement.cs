using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public bool is_walking;

    public float moving_speed, move_distance, rotate_speed;

    public Vector3 target_position;

    public Quaternion facing;

    private Vector3 ray_direction;
    private Vector3[] direction = new Vector3[4] { new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(0, 0, -1), new Vector3(-1, 0, 0) };

    private bool[] walkable = new bool[4];

    private float collider_radius;




    // Start is called before the first frame update
    void Start()
    {
        collider_radius = GetComponent<CapsuleCollider>().radius;

        target_position = transform.position;

        set_direction();
    }

    // Update is called once per frame
    void Update()
    {
        set_direction();

        if (transform.position == target_position && !GameManager.game_end)
        {
            Invoke("Move", 0);
        }
        else
        {
            Rotation_and_Movment();
        }

    }

    void Move()
    {
        if (Physics.Raycast(transform.position + (ray_direction * collider_radius), ray_direction, move_distance - collider_radius, LayerMask.GetMask("Obstacle")) == false)
        {
            int random = Random.Range(0, 8);


            if (random == 0)
            {
                target_position += direction[Change_Facing()] * move_distance;
            }
            else
            {
                target_position += ray_direction * move_distance;
            }

        }
        else if (Physics.Raycast(transform.position + (ray_direction * collider_radius), ray_direction, move_distance - collider_radius, LayerMask.GetMask("Obstacle")) == true)
        {
            target_position += direction[Change_Facing()] * move_distance;
        }
    }




    int Change_Facing()
    {
        int random;

        Check_Walkable();


    Tag_1:
        random = Random.Range(0, 4);

        if (walkable[random])
        {
            facing = Quaternion.Euler(0, 90 * random, 0);

            return random;
        }
        else
        {
            goto Tag_1;
        }
        
    }

    void Rotation_and_Movment()
    {
        if (transform.rotation.eulerAngles.y != facing.eulerAngles.y)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, facing, rotate_speed * Time.deltaTime);
        }

        if (transform.position != target_position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target_position, moving_speed * Time.deltaTime);

            is_walking = true;
        }
        else
        {
            is_walking = false;
        }
    }


    void set_direction()
    {
        if (facing.eulerAngles.y == 0)
        {
            ray_direction = direction[0];
        }
        else if (facing.eulerAngles.y == 90)
        {
            ray_direction = direction[1];
        }
        else if (facing.eulerAngles.y == 180)
        {
            ray_direction = direction[2];
        }
        else if (facing.eulerAngles.y == 270)
        {
            ray_direction = direction[3];
        }
    }


    void Check_Walkable()
    {
        for (int i = 0; i < 4; i++)
        {
            if(90 * i == transform.rotation.eulerAngles.y)
            {
                walkable[i] = false;
                continue;
            }


            if(Physics.Raycast(transform.position + (direction[i] * collider_radius), direction[i], move_distance - collider_radius, LayerMask.GetMask("Obstacle")))
            {
                walkable[i] = false;

                
            }
            else
            {
                walkable[i] = true;
            }
        }
    }



}
