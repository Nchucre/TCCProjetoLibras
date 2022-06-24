using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeVento : MonoBehaviour
{
    public  GameObject       canvasEnigma;
    private     CameraFollow    cameraControler;
    private     Controlador     gameControlador;
    private     PlayerMove      player;
    private     Fade    fade;
    public      Camera  puzzleCamVento, mainCam;
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
        StartCoroutine("AcionarCena");
        cameraControler.cameraPlayer = false;
        colisorParede.enabled = false;
        player.playerRb.velocity = new Vector2(0, 0);
    }

    IEnumerator AcionarCena()
    {
        gameControlador.MudarMaquinaEstado(MaquinaEstado.PUZZLE);
        fade.FadeIn();
        cameraControler.cameraPlayer = false;
        yield return new WaitWhile(() => fade.fume.color.a < 0.9f);
        mainCam.transform.position = puzzleCamVento.transform.position;
        canvasEnigma.SetActive(true);//ativa o enigma
        fade.FadeOut();
    }
}
