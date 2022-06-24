using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinVida : MonoBehaviour
{
    public      GameObject      canvasEnigma, animaVida;
    private     PlayerMove      player;
    private     CameraFollow    cameraControler;
    private     Controlador    gameControlador;
    private     int         pontosMax, pontos;
    private     Fade        fade;
    //public      GameObject  letras;
    // Start is called before the first frame update
    void Start()
    {
        //pontosMax = letras.transform.childCount;
        pontosMax = 4;
        cameraControler = FindObjectOfType(typeof(CameraFollow)) as CameraFollow;
        gameControlador = FindObjectOfType(typeof(Controlador)) as Controlador;
        player = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;
        fade = FindObjectOfType(typeof(Fade)) as Fade;
        fade.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        if(pontos >= pontosMax)
        {
            canvasEnigma.SetActive(false);//desativa o enigma
            cameraControler.cameraPlayer = true;
            gameControlador.hp += 20;
            gameControlador.hpatual += 20;
            gameControlador.poderesPassivos[1] = true;
            gameControlador.MudarMaquinaEstado(MaquinaEstado.JOGANDO);
            Instantiate(animaVida, player.transform.position, player.transform.rotation);
            Destroy(this.gameObject);
        }
    }

   public void AddPontosVida()
    {
        pontos++;
    }
}
