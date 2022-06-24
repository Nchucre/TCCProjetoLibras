using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFinal : MonoBehaviour
{
    //public  GameObject      cam;
    private CameraFollow    cameraScript;
    public  Animator    giganteAnimator;
    private Controlador gameControler;
    public  Collider2D  triggerAbaixaMao, colisorDedo;
    // Start is called before the first frame update
    void Start()
    {
        gameControler = FindObjectOfType(typeof(Controlador)) as Controlador;
        cameraScript = FindObjectOfType(typeof(CameraFollow)) as CameraFollow;
        colisorDedo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D colisor)
    {
        gameControler.MudarMaquinaEstado(MaquinaEstado.DIALOGANDO);
        if(colisor.gameObject.CompareTag("Player"))
        {
            //Camera.main.SetActive(false);
            //cam.SetActive(true);
            cameraScript.cameraPlayer = false;
            giganteAnimator.SetBool("Desce", true);
            triggerAbaixaMao.enabled = false;
            colisorDedo.enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D colisor)
    {
        gameControler.MudarMaquinaEstado(MaquinaEstado.JOGANDO);
    }

}
