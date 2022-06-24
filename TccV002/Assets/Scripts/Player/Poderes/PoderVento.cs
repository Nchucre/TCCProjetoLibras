using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderVento : MonoBehaviour
{
    
    public float        speed;
    public Rigidbody2D  poderrb;
    public GameObject   explosão;
    public int          dano;
    public string       tipoDano;
    void Start()
    {
        poderrb.velocity = transform.right * speed;
        dano = 10;
        tipoDano = "vento";
    }

    void Update()
    {
        Destroy(this.gameObject, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        //aqui se causa dano e envia o dano para o inimigo

        //aqui a gente explode e destroi o poder
        Instantiate(explosão, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
