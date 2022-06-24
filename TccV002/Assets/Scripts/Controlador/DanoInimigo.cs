using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = this.gameObject.GetComponent<Zumbi>().hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        //Debug.Log("Hit");
        if(colisor.gameObject.CompareTag("BolaFogo"))
        {
            int dano = colisor.gameObject.GetComponent<PoderdeFogo>().dano;
        }
    }
}
