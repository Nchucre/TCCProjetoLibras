using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RostoCongelado : MonoBehaviour
{
    private Animator    rostoAnimations;
    private bool        hit = false;
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

    void OnTriggerEnter2D(Collider2D colisor)
    {
        hit = true;
    }
}
