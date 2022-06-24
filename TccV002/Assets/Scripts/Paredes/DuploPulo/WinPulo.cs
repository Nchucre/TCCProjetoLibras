using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPulo : MonoBehaviour
{
    public      GameObject      canvasEnigma;
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
            gameControlador.poderesPassivos[0] = true;
            gameControlador.MudarMaquinaEstado(MaquinaEstado.JOGANDO);
            Destroy(this.gameObject);
        }
    }

   public void AddPontosEscudoAgua()
    {
        pontos++;
    }
}
