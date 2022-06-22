using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Collision_Trigger : MonoBehaviour
{
    static Player_Movement player_Movement;

    Particle particle;

    Audio audio;

    private void Awake()
    {
        audio = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<Audio>();

        particle = GetComponent<Particle>();
        player_Movement = GetComponent<Player_Movement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Non_Passable_Wall();
        }
        else if (other.gameObject.tag == "GreenWall" && Player_Condition.condition != "Green")
        {
            Non_Passable_Wall();
            
        }
        else if(other.gameObject.tag == "RedWall" && Player_Condition.condition != "Red")
        {
            Non_Passable_Wall();
            
        }
        else if(other.gameObject.tag == "WhiteWall" && Player_Condition.condition != "White")
        {
            Non_Passable_Wall();
           
        }

        if(other.gameObject.tag == "Enemy")
        {
            Trigger_With_Enemy(other);
        }

        if(other.gameObject.tag == "Pickup")
        {
            Trigger_With_Pickups(other.gameObject);
        }

        if(other.gameObject.tag == "EndGoal")
        {
            GameManager.game_end = true;
            player_Movement.target_position = transform.position;


            Invoke("GameWin", 1);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if((other.gameObject.tag == "GreenWall" && Player_Condition.condition == "Green") || (other.gameObject.tag == "WhiteWall" && Player_Condition.condition == "White") || (other.gameObject.tag == "RedWall" && Player_Condition.condition == "Red"))
        {
            Player_Condition.condition = "Normal";
        }
    }




    void Non_Passable_Wall()
    {
        if (transform.position.x != gameObject.GetComponent<Player_Movement>().target_position.x)
        {
            if (transform.position.x > gameObject.GetComponent<Player_Movement>().target_position.x)
            {
                gameObject.GetComponent<Player_Movement>().target_position += new Vector3(gameObject.GetComponent<Player_Movement>().move_distance, 0, 0);
            }
            else if (transform.position.x < gameObject.GetComponent<Player_Movement>().target_position.x)
            {
                gameObject.GetComponent<Player_Movement>().target_position -= new Vector3(gameObject.GetComponent<Player_Movement>().move_distance, 0, 0);
            }

        }
        else if (transform.position.z != gameObject.GetComponent<Player_Movement>().target_position.z)
        {
            if (transform.position.z > gameObject.GetComponent<Player_Movement>().target_position.z)
            {
                gameObject.GetComponent<Player_Movement>().target_position += new Vector3(0, 0, gameObject.GetComponent<Player_Movement>().move_distance);
            }
            else if (transform.position.z < gameObject.GetComponent<Player_Movement>().target_position.z)
            {
                gameObject.GetComponent<Player_Movement>().target_position -= new Vector3(0, 0, gameObject.GetComponent<Player_Movement>().move_distance);
            }
        }
    }



    private void Trigger_With_Enemy(Collider collision)
    {
        PlayerManager.is_player_dead = true;
        GameManager.game_end = true;

        player_Movement.target_position = transform.position;
        collision.gameObject.GetComponent<Enemy_Movement>().target_position = collision.gameObject.transform.position;


        if (collision.gameObject.transform.position.x < transform.position.x)
        {
            collision.gameObject.GetComponent<Enemy_Movement>().facing = Quaternion.Euler(0, 90, 0);
        }
        else if (collision.gameObject.transform.position.x > transform.position.x)
        {
            collision.gameObject.GetComponent<Enemy_Movement>().facing = Quaternion.Euler(0, 270, 0);
        }
        else if (collision.gameObject.transform.position.z < transform.position.z)
        {
            collision.gameObject.GetComponent<Enemy_Movement>().facing = Quaternion.Euler(0, 0, 0);
        }
        else if (collision.gameObject.transform.position.z > transform.position.z)
        {
            collision.gameObject.GetComponent<Enemy_Movement>().facing = Quaternion.Euler(0, 180, 0);
        }

        audio.Play_One_Shot(audio.attack);
        collision.gameObject.GetComponent<Enemy_Animation>().Play_One_Shot_Attack();


        Invoke("GameLose", 1);
    }
    
    
    private void Trigger_With_Pickups(GameObject gameobject)
    {
        switch(gameobject.GetComponent<Pickup_Script>().Name)
        {
            case "Tomato":
                {
                    particle.Particle_Emission(particle.Red_Particle);

                    Player_Condition.tomato++;

                    break;
                }
            case "Cream":
                {
                    particle.Particle_Emission(particle.White_Particle);

                    Player_Condition.cream++;

                    break;
                }
            case "Basil":
                {
                    particle.Particle_Emission(particle.Green_Particle);

                    Player_Condition.basil++;

                    break;
                }
            case "Wheat":
                {
                    particle.Particle_Emission(particle.Gold_Particle);

                    GameManager.Score += 10;
                    GameManager.current_score += 10;

                    break;
                }
        }

        Destroy(gameobject);
    }



    private void GameWin()
    {
        player_Movement.target_position = transform.position;

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
        }
        else
        {
            if (GameManager.Score >= 500)
            {
                audio.Stop_BGM();

                SceneManager.LoadScene("GameWin");
            }
            else
            {
                GameLose();
            }
        }    
    }

    private void GameLose()
    {
        audio.Stop_BGM();

        GameManager.game_end = false;

        SceneManager.LoadScene("GameLose");
    }
}
