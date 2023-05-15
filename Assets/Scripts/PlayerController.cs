using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float move;
    public float speed;
    public bool floor = false;
    public float force;

    public Rigidbody2D rigid;
    public GameObject shootPrefab;
    public Transform shootSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        //Move horizontal
        move = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(move * speed, rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a wine bottle from the player
            //Instantiate(shootPrefab, shootSpawnPoint.position, shootPrefab.transform.rotation);
        }
    }

    void FixedUpdate()
    {
        //Salto
        if (Input.GetButtonDown("Jump")&& floor)
        {
            rigid.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
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
}
