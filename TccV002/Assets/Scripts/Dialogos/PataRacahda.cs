using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PataRacahda : MonoBehaviour
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
            caixaTexto.text = "Eu realmente to no inferno não é?? Do contrario não veria aquilo";
            
        }
        if(idFala == 1)
        {
            falante[0].enabled = false;
            falante[1].enabled = true;
            caixaTexto.text = "Eu não chegaria muito perto se fosse você";
            
        }
        if(idFala == 2)
        {
            falante[0].enabled = true;
            falante[1].enabled = false;
            caixaTexto.text = "Ele é tão ruim quanto dizem??";
            
        }
        if(idFala == 3)
        {
            falante[0].enabled = false;
            falante[1].enabled = true;
            caixaTexto.text = "Ele controla tudo por aqui, apesar de estar congelado e preso da cintura pra baixo";
            
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
