using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ParedeFogo : MonoBehaviour
{
    //variaveis dialogo
    public  GameObject      canvasDialogo, canvasEnigma;
    public  TMP_Text        caixaTexto;
    private int             idFala;
    private bool            falando = false;
    public  string[]        falas;
    //varaiveis camera
    private     CameraFollow    cameraControler;
    private     Controlador     gameControlador;
    private     PlayerMove      player;
    private     Fade    fade;
    public      Camera  puzzleCam, mainCam;
    public      Collider2D  colisorParede;
     void Start()
    {
        fade = FindObjectOfType(typeof(Fade)) as Fade;
        cameraControler = FindObjectOfType(typeof(CameraFollow)) as CameraFollow;
        gameControlador   = FindObjectOfType(typeof(Controlador)) as Controlador;
        player   = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;
    }

    public void interacao()
    {
        if(gameControlador.possuiLivro == true)
        {
            StartCoroutine("AcionarCena");
        // cameraControler.cameraPlayer = false;
            colisorParede.enabled = false;
            player.playerRb.velocity = new Vector2(0, 0);
        }
        else
        {
            if(falando == false)
            {
                gameControlador.MudarMaquinaEstado(MaquinaEstado.DIALOGANDO);
                idFala = 0;
                caixaTexto.text = falas[idFala];
                canvasDialogo.SetActive(true);
                falando = true;
            }
            else
            {
                idFala++;
                Dialogo();
            }

        }
    }

    IEnumerator AcionarCena()
    {
        gameControlador.MudarMaquinaEstado(MaquinaEstado.PUZZLE);
        fade.FadeIn();
        cameraControler.cameraPlayer = false;
        yield return new WaitWhile(() => fade.fume.color.a < 0.9f);
        mainCam.transform.position = puzzleCam.transform.position;
        canvasEnigma.SetActive(true);//ativa o enigma
        fade.FadeOut();
        //SceneManager.LoadScene("ParedeFogo");
    }

    public void Dialogo()
    {
        if(idFala < falas.Length)
        {
            caixaTexto.text = falas[idFala];
        }
        else 
        {
            canvasDialogo.SetActive(false);
            falando = false;
            gameControlador.MudarMaquinaEstado(MaquinaEstado.JOGANDO);
        }
    }
}
