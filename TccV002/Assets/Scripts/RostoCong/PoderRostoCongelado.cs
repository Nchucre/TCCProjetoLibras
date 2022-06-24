using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderRostoCongelado : MonoBehaviour
{
    public Transform    firePoint;
    public GameObject   poder;
    private bool        ataca;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ataca)
        {
            SoltarPoder();
            ataca = false;
        }
    }

    void SoltarPoder()
    {
        Instantiate(poder, firePoint.position, firePoint.rotation);
    }

    public void BocaAberta(int bocaAberta)
    {
        switch (bocaAberta)
        {
            case 0:
            ataca = false;
            break;
            case 1:
            ataca = true;
            break;
        }


    }
}
