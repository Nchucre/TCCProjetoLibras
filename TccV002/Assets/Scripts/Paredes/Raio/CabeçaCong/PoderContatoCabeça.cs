using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderContatoCabeça : MonoBehaviour
{
    private  PlayerMove player;
    public  Rigidbody2D poderrb;
    public  GameObject  explosao;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;

        if(player.transform.position.x < this.transform.position.x)
        {
            poderrb.velocity = transform.right * -9;
        }
        if(player.transform.position.x > this.transform.position.x)
        {
            poderrb.velocity = transform.right * 9;
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        Instantiate(explosao, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        Instantiate(explosao, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
