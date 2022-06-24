using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PataRachada : MonoBehaviour
{
    private PlayerMove playerScript;
    private Controlador gameControler;
    // Start is called before the first frame update
    void Start()
    {
        gameControler = FindObjectOfType(typeof(Controlador)) as Controlador;
        playerScript = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D colisor)
    {
        playerScript.playerAnimations.SetInteger("idAnimation", 2);
        gameControler.hpatual = 0;
    }
}
