using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Nono03Placa01 : MonoBehaviour
{
    public  GameObject      cameraCutscene;
    private Controlador     gameControler;
    private PlayerMove      player;
    public  GameObject      canvasDialogo;
    //public  Image           falante;
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
            cameraCutscene.SetActive(true);
            canvasDialogo.SetActive(true);
            gameControler.MudarMaquinaEstado(MaquinaEstado.DIALOGANDO);
            player.playerAnimations.SetInteger("idAnimation", 0);
            falante[0].enabled = true;
            falante[1].enabled = false;
            caixaTexto.text = "O QUE SÃO ESSAS COISAS GIGANTES??";
            
        }
        if(idFala == 1)
        {
            falante[0].enabled = false;
            falante[1].enabled = true;
            caixaTexto.text = "Isso mesmo que você falou... Gigantes.";
            
        }
        if(idFala == 2)
        {
            falante[0].enabled = true;
            falante[1].enabled = false;
            caixaTexto.text = "Claro, mas não sabia que havia gigantes no inferno";
            
        }
        if(idFala == 3)
        {
            falante[0].enabled = false;
            falante[1].enabled = true;
            caixaTexto.text = "Há seis, cinco deles estão acorrentados e presos pela eternidade. Com sorte o que está solto nos ajuda a passar pela muralha. Afinal ele ja fez isso no passado";
            
        }
        if(idFala > 3)
        {
            canvasDialogo.SetActive(false);
            cameraCutscene.SetActive(false);
            gameControler.MudarMaquinaEstado(MaquinaEstado.JOGANDO);
            colisor.enabled = false;
        }
    }
}
