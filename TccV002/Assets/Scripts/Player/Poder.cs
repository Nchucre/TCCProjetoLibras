using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poder : MonoBehaviour
{
    public Transform    firePoint;
    public Transform    shieldPoint;
    public Transform    poderEspecialPos;
    private Controlador gameControler;
    private PlayerMove  player;
    private GameObject   poder, escudo, poderEspecial;
    public bool atk = false, def = true, especial = true;
    


    void Start()
    {
        gameControler = FindObjectOfType(typeof(Controlador)) as Controlador;
        player = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && gameControler.quantPoderes >= 1 && player.hit == false)
        {
            SoltaPoder();
        }

        if(Input.GetButtonDown("Fire2") && gameControler.quantEscudos >= 1 && player.hit == false)
        {
            if(def == true)
            {
                AtivaEscudo();
            }
        }

        if(Input.GetButtonDown("Fire3") && gameControler.quantPoderes >= 3 && player.hit == false)
        {
            if(especial == true)
            SoltaEspecial();
        }

        if(gameControler.poderes[2] == true)
            poderEspecial = gameControler.poder[2];
        //com certeza tem que criar um novo array pra poder especial, como vai ter so um poder especial
        //da pra fazer essa gambiarra aqui
        poder = gameControler.poder[gameControler.idPoderAtual];
        if(gameControler.escudos[0])
            escudo = gameControler.escudo[gameControler.idEscudoAtual];
    }
    
    void SoltaPoder()
    {
        if(atk == true && gameControler.poderes[gameControler.idPoderAtual] == true)
        {
            Instantiate(poder, firePoint.position, firePoint.rotation);
            atk = false; //essa linha faz com que o player não ataque mais de uma vez seguida
        }
    }

    void AtivaEscudo()
    {
        if(gameControler.escudos[gameControler.idEscudoAtual] == true)
        {
            def = false;
            Instantiate(escudo, shieldPoint.position, shieldPoint.rotation);
            StartCoroutine("TempoEscudo");
        }
    }

    void SoltaEspecial()
    {
        //fazer o if pra reconhecer o poder
        especial = false;
        Instantiate(poderEspecial, poderEspecialPos.position, poderEspecialPos.rotation);
        StartCoroutine("TempoEspecial");
    }

    public void AtacaAnima(int ataca)
    {
        switch (ataca)
        {
            case 0:
                atk = false;
                break;
            case 1:
                atk = true;
                break;
        }
    }

    IEnumerator TempoEscudo()
    {
        yield return new WaitForSeconds(5f);
        def = true;
    }

    IEnumerator TempoEspecial()
    {
        yield return new WaitForSeconds(10f);
        especial = true; 
    }
}
