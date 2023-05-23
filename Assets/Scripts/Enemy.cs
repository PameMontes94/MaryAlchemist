using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public float velocity;
    public float vida ;
    private Animator animator;
    // Update is called once per frame
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void tomarImpacto(float impacto)
    {
        vida -= impacto;

        if (vida <=  0)
        {
            Destroy(gameObject);
        }
    }
}
