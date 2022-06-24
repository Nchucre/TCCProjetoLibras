using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raio : MonoBehaviour
{
    public Collider2D colisorRaio;
    // Start is called before the first frame update
    void Start()
    {
        colisorRaio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaioCaiu(int raio)
    {
        switch(raio)
        {
            case 0:
                colisorRaio.enabled = true;
                break;
            case 1:
                colisorRaio.enabled = false;
                break;
            case 2:
                Destroy(this.gameObject);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.CompareTag("Inimigo"))
        {
            Destroy(colisor.gameObject);
        }
    }
}
