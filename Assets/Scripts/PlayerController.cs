using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float move;
    public float speed;
    public bool floor = true;
    public float force;
    private bool mirandoDerecha = true;

    public Rigidbody2D rigid;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        //Move horizontal
        move = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(move * speed, rigid.velocity.y);

        if (move > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (move < 0 && mirandoDerecha)
        {
            Girar();
        }

        animator.SetFloat("Horizontal", Mathf.Abs(move));
    }

    void FixedUpdate()
    {
        //Salto
        if (Input.GetButtonDown("Jump")&& floor)
        {
            rigid.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
    //Girar personaje
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
    //Validar si está tocando piso
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            floor = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collisionpiso)
    {
        if (collisionpiso.gameObject.tag == "Floor")
        {
            floor = false;
        }
    }

    //Destroy Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Enemy"))
        {
            Muerte();
        }
    }
    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}
