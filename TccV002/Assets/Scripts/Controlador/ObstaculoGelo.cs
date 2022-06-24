using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoGelo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.CompareTag("Poder"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
