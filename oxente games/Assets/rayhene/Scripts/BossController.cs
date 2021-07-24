using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;

public class BossController : MonoBehaviour
{
    public float speed;
    public float attackRadius;
    
    public bool shouldRotate;
    public LayerMask whatIsPlayer;
    
    public Rigidbody2D rb;
    public Animator animator;

    private Transform target;
    private Vector2 movement; 
    public Vector3 direction;

    private bool isInChaseRange;
    private bool isInAttackRange;

    public FieldOfView fieldOfView;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        fieldOfView = GetComponent<FieldOfView>();

        target = GameObject.FindWithTag("player").transform;

    }

    void Update()
    {
        isInChaseRange = fieldOfView.FindVisibleTargets();
        animator.SetBool("isRunning", isInChaseRange);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
        
        direction = (target.position - transform.position).normalized;
        
        movement = direction;

        if (shouldRotate)
        {
            animator.SetFloat("X", direction.x);
            animator.SetFloat("Y", direction.y);
        }
    }
    void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveBoss(movement);
        }

        if (isInAttackRange)
        {
            print("entrou no range de ataque");
            rb.velocity = Vector2.zero;
            //É pra fazer pra fazer um metodo de ataque aqui 
            
        }
        
    }
    private void MoveBoss(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    
    

}