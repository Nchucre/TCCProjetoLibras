using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MsgMundo : MonoBehaviour
{
    //public GameObject Hud;
    private  Controlador    gameControler;
    //private  PlayerMove     playerScript;
    private  Fade           fade;
    public  GameObject      canvasDialogo;
    public  TMP_Text        caixaTexto;
    //private int             idFala;
    //public  bool[]          idTexto;
    //private bool            falando;
    //public  string[]        falas;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DialogoStart");
        gameControler = FindObjectOfType(typeof(Controlador)) as Controlador;
        fade = FindObjectOfType(typeof(Fade)) as Fade;
    }

    // Update is called once per frame
    void Update()
    { 
        if(gameControler.hpatual <= 0)
        {
            StartCoroutine("Morte");
        }

    }

    IEnumerator DialogoStart()
    {  
        canvasDialogo.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        canvasDialogo.SetActive(false);
    }

    IEnumerator Morte()
    {
        canvasDialogo.SetActive(true);
        caixaTexto.text = "Você morreu";
        fade.FadeIn();
        yield return new WaitForSecondsRealtime(4f);
        canvasDialogo.SetActive(false);
        //Destroy(Hud); //se não destruir o HUD atual vai ter dois hud quando recarregar a cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
