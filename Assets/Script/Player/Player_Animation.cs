using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Player_Animation : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        walking_animation();

        Dead_Animation();
    }

    void walking_animation()
    {
        if(GameManager.horizontal_input != 0 || GameManager.vertical_input != 0 || gameObject.GetComponent<Player_Movement>().target_position != transform.position)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }


    public void Dead_Animation()
    {
        animator.SetBool("IsDead", PlayerManager.is_player_dead);
    }
}
