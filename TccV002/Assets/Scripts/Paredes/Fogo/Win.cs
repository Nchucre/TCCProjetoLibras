using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
//CODIGO PARA A VITORIA DO PUZZLE DE FOGO
    //Variaveis para dialogo de vitoria
    public  GameObject      canvasEnigma;
    //variaveis para puzzle
    private     CameraFollow    cameraControler;
    private     Controlador     gameControlador;
    private     int         pontosMax, pontos;
    private     Fade        fade;
    //public      GameObject  letras;
    // Start is called before the first frame update
    void Start()
    {
        pontosMax = 4;
        //pontosMax = letras.transform.childCount;
        gameControlador = FindObjectOfType(typeof(Controlador)) as Controlador;
        cameraControler = FindObjectOfType(typeof(CameraFollow)) as CameraFollow;
        fade = FindObjectOfType(typeof(Fade)) as Fade;
        fade.FadeOut(); //pra que haja um fadeOut precisa ter um fadeIn
    }

    // Update is called once per frame
    void Update()
    {
        if(pontos >= pontosMax)
        {
        canvasEnigma.SetActive(false);//desativa o enigma
        cameraControler.cameraPlayer = true; //possivel bug, ao vencer uma vez essa linha é chamada 
                                            //o tempo todo então nunca desativa o cameraplayer
        gameControlador.poderes[0] = true;
        gameControlador.quantPoderes = 1;
        gameControlador.MudarMaquinaEstado(MaquinaEstado.JOGANDO);
        Destroy(this.gameObject);              //isso corrige o bug, destruindo o objeto o cameraPlayer
                                                 //não fica se atualizando
        //SceneManager.LoadScene("Nono01");
        }
    }

   public void AddPontosFogo()
    {
        pontos++;
    }
}
