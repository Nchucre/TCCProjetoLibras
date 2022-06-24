using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabeçaCong : MonoBehaviour
{
    private Animator    rostoAnimations;
    public  Collider2D  colisorCabeca;
    public bool        hit = false;
    void Start()
    {
        rostoAnimations = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
            rostoAnimations.SetTrigger("Hit");
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        hit = true;
        colisorCabeca.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        hit = true;
        colisorCabeca.enabled = false;
    }
}
