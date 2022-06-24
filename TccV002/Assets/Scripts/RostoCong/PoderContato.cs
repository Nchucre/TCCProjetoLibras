using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderContato : MonoBehaviour
{
    public  float       speed;
    public  Rigidbody2D poderrb;
    public  GameObject  explosao;
    // Start is called before the first frame update
    void Start()
    {
        poderrb.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        Instantiate(explosao, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
