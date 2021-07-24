using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 moveInput;
    public Animator animator;
    public GameObject lanterna;

   
    public static bool blockInput = false;
    public GameObject bala;
    public Transform arma;



    // Start is called before the first frame update
    void Start()
    {


        transform.position = new Vector3(GameData.pos_inicialX, GameData.pos_inicialY, 0);


    }

    // Update is called once per frame
    void Update()
    {

        Aim();
        Shoot();

    }

    void Aim()
    {


        if (blockInput == false)
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePos1 = Input.mousePosition;
            Vector3 screenPoint1 = Camera.main.WorldToScreenPoint(arma.position);

            Vector2 offset = new Vector2(mousePos1.x - screenPoint1.x, mousePos1.y - screenPoint1.y);

            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            arma.rotation = Quaternion.Euler(0, 0, angle);
        


            mousePos.z = transform.position.z;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        
            lanterna.transform.rotation = targetRotation;


        
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");
            transform.Translate(moveInput * Time.deltaTime * moveSpeed);
            lanterna.transform.Rotate(0, 0, moveInput.y - moveInput.x);
            animator.SetFloat("horizontal", moveInput.x);
            animator.SetFloat("vertical", moveInput.y);
            animator.SetFloat("velocidade", moveInput.sqrMagnitude);

            if (moveInput != Vector2.zero)
            {
                animator.SetFloat("horizontalparado", moveInput.x);


                animator.SetFloat("verticalparado", moveInput.y);

            }


            



        }
        
        
    }

    void Shoot()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bala, arma.position,arma.rotation);
        }*/
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "porta" && GameData.chave == true)
        {
            string proxima = "";
            blockInput = true;
            animator.Play("entrandonaporta");
            if (GameData.sala == 0)
            {
                proxima = "cenaquarto";
                GameData.sala = 1;
                GameData.pos_inicialX = 3.31f;
                GameData.pos_inicialY = -3.52f;
            }
            else if (GameData.sala == 1)
            {
                proxima = "cenasaladejantar";
                GameData.sala = 2;
                GameData.pos_inicialX = 1.67f;
                GameData.pos_inicialY = -4.09f;
            }
            else if (GameData.sala == 2)
            {
                proxima = "cenacozinha";
                GameData.sala = 3;
                GameData.pos_inicialX = 8.2f;
                GameData.pos_inicialY = -0.55f;
            }
            else if (GameData.sala == 4)
            {
                proxima = "cenasaguao";
                GameData.sala = 5;
                GameData.pos_inicialX = -0.28f;
                GameData.pos_inicialY = 3.05f;
            }
            Debug.Log(proxima);
            StartCoroutine(espera(proxima));
            

        }

        if (collision.gameObject.tag == "portalivre")
        {

            blockInput = true;

            animator.Play("entrandonaporta");
            string proxima = "";
            if (GameData.sala == 3)
            {
                proxima = "cenabiblioteca";
                GameData.sala = 4;
                GameData.pos_inicialX = 8.15f;
                GameData.pos_inicialY = -1.21f;
            }
            StartCoroutine(espera(proxima));
        }
    }

    IEnumerator espera(string proxima)
    {
        yield return new WaitForSeconds(2f);
        blockInput = false;
        SceneManager.LoadScene(proxima);
        GameData.chave = false;
    }



}
