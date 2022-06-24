using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderCabeçaCong : MonoBehaviour
{
    public Transform    firePoint;
    public Collider2D   colisorcabeca;
    public GameObject   poder;
    private bool        ataca, direita;
    public  LayerMask   vistaPlayer;
    void Start()
    {
        if(this.transform.localScale.x > 0)
        {
            direita = false;
        }
        if(this.transform.localScale.x < 0)
        {
            direita = true;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D playerInfo;
        if(direita)
        {
        playerInfo = Physics2D.Raycast(firePoint.transform.position, transform.right, 5f, vistaPlayer);
        Debug.DrawRay(firePoint.transform.position, transform.right * 5f, Color.red);
        }
        else
        {
        playerInfo = Physics2D.Raycast(firePoint.transform.position, -transform.right , 5f, vistaPlayer);
        Debug.DrawRay(firePoint.transform.position, -transform.right * 5f, Color.red);
        }

        if(ataca && playerInfo && colisorcabeca.enabled == true)
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
