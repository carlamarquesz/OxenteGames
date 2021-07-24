using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstrocontroller : MonoBehaviour
{

    [SerializeField] float speed;
    GameObject player;
    Animator anim;
    bool vivo = true;
    public HealthBar healthBar;
    HealthSystem healthSystem;
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

    private int monsterDamage;

    public FieldOfView fieldOfView;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        anim = GetComponentInChildren<Animator>();
        healthSystem = new HealthSystem(10);
        healthBar.Setup(healthSystem);
        fieldOfView = GetComponent<FieldOfView>();
        target = GameObject.FindWithTag("player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        /* if(player != null && vivo)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        */
        isInChaseRange = fieldOfView.FindVisibleTargets();
        //Debug.Log(isInChaseRange);
        //animator.SetBool("isRunning", isInChaseRange);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
        Debug.Log(target.position);
        direction = (target.position - transform.position).normalized;

        movement = direction;

        if (shouldRotate)
        {
            animator.SetFloat("X", direction.x);
            animator.SetFloat("Y", direction.y);
        }
        if (vivo == false)
        {
            anim.SetTrigger("dead");
            Destroy(gameObject, 0.5f);
        }
    }
    private void MoveBoss(Vector2 direction)
    {
        Debug.Log(direction);
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    private void Attack()
    {
        /* GetComponent<HealthSystem>().Damage(monsterDamage);   ou algo do tipo */
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

            /*attack();*/

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala"))
        {
            healthSystem.Damage(1);
            if (healthSystem.GetHealth() <= 0){
                vivo = false;
            }
        }
    }


}
