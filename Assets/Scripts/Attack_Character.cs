using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack_Character : MonoBehaviour
{
    public Transform controlGolpe;
    public float radioGolpe;
    public float impactoGolpe;

    private Animator  animator;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private void Update()
    {
        if(Input.GetButtonDown("Atack"))
        {
            Golpe();
        }
    }
    private void Golpe()
    {
        animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controlGolpe.position, radioGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            if(colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<Enemy>().tomarImpacto(impactoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(controlGolpe.position, radioGolpe);
    }
}
