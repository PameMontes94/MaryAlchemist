using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject munition;
    public Transform munitionTarget;
    void Update()
        {
            if (Input.GetButtonDown("Disparo"))
            {
                shot();
            }
        }

        void shot()
        {
            Instantiate(munition, munitionTarget.position, munitionTarget.rotation);
        }
    
}
