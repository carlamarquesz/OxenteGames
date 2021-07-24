using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoController : MonoBehaviour
{
    public float speed;
    public float checkRadius;
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
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        target = GameObject.FindWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", isInChaseRange);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        direction = target.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
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
            Debug.Log("entrou no range de ataque");
            rb.velocity = Vector2.zero;
            

        }
    }
    private void MoveBoss(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    


}
