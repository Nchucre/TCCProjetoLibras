using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Nono02Placa01 : MonoBehaviour
{
    private Controlador     gameControler;
    private PlayerMove      player;
    public  GameObject      canvasDialogo;
    public  Image[]         falante;
    public  TMP_Text        caixaTexto;
    public  Collider2D      colisor;
    private int             idFala;
    
    // Start is called before the first frame update
    void Start()
    {
        gameControler = FindObjectOfType(typeof(Controlador)) as Controlador;
        player = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;
        idFala = 0;
    }

    // Update is called once per frame
    public void interacao()
    {
        Dialogo();
        idFala++;
    }

    public void Dialogo()
    {
        
        if(idFala == 0)
        {
            canvasDialogo.SetActive(true);
            gameControler.MudarMaquinaEstado(MaquinaEstado.DIALOGANDO);
            player.playerAnimations.SetInteger("idAnimation", 0);
            falante[0].enabled = true;
            caixaTexto.text = "Aqui estão aqueles que trairam sua pátria";
            
        }
        if(idFala == 1)
        {
            caixaTexto.text = "Seu nome, \"Esfera da Antenora\", foi tirado de Antenor, principe troiano que traiu seu país...";
            
        }
        if(idFala == 2)
        {
            caixaTexto.text = "...ao trocar informações secretamente com gregos.";
            
        }
        if(idFala > 2)
        {
            canvasDialogo.SetActive(false);
            gameControler.MudarMaquinaEstado(MaquinaEstado.JOGANDO);
            colisor.enabled = false;
        }
    }
}
