using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEscudoAgua : MonoBehaviour
{ // Start is called before the first frame update
    public      GameObject      canvasEnigma;
    //public      GameObject      circuloEscudos;
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
            gameControlador.escudos[0] = true;
            gameControlador.quantEscudos = 1;
            //circuloEscudos.SetActive(true);
            gameControlador.MudarMaquinaEstado(MaquinaEstado.JOGANDO);
            Destroy(this.gameObject);
        }
    }

   public void AddPontosPulo()
    {
        pontos++;
    }
}
