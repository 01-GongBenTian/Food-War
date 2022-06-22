using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy_Animation : MonoBehaviour
{
    Animator animator;

    Enemy_Movement enemy_Movement;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        enemy_Movement = GetComponent<Enemy_Movement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Walking_Animation();
    }

    void Walking_Animation()
    {
        animator.SetBool("IsWalking", enemy_Movement.target_position != transform.position);
    }

    public void Play_One_Shot_Attack()
    {
        animator.SetTrigger("IsAttack");
    }
}
