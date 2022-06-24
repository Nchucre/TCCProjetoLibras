using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Livro : MonoBehaviour
{
    private  Controlador    gameControler;
    private  PlayerMove     player;
    public  GameObject      canvasDialogo;
    public  TMP_Text        caixaTexto;
    private int             idFala;
    private bool            falando;
    public  string[]        falas;
    // Start is called before the first frame update
    void Start()
    {
        gameControler = FindObjectOfType(typeof(Controlador)) as Controlador;
        player = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;
    }

    public void interacao()
    {
        if(falando == false)
        {
            idFala = 0;
            caixaTexto.text = falas[idFala];
            canvasDialogo.SetActive(true);
            gameControler.MudarMaquinaEstado(MaquinaEstado.DIALOGANDO);
            falando = true;
        }
        else
        {
            idFala++;
            Dialogo();
        }
    }

    public void Dialogo()
    {
        if(idFala < falas.Length)
        {
            caixaTexto.text = falas[idFala];
        }
        else
        {
            gameControler.MudarMaquinaEstado(MaquinaEstado.JOGANDO);
            canvasDialogo.SetActive(false);
            falando = false;
            gameControler.possuiLivro = true;
            Destroy(this.gameObject); // isso aqui é so pelo livro nada a ver com a fala
        }
    }
}
