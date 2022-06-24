using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public  GameObject  buttomInicia, buttomCreditos, buttomSair, canvasCreditos;
    public  bool        lendoCreditos;
    // Start is called before the first frame update
    void Start()
    {
        buttomInicia.SetActive(true);
        buttomCreditos.SetActive(true);
        buttomSair.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") && lendoCreditos == true)
        {
            lendoCreditos = false;
            canvasCreditos.SetActive(false);
            buttomInicia.SetActive(true);
            buttomCreditos.SetActive(true);
            buttomSair.SetActive(true);
        }
    }

    public void ButtomInicial()
    {
        SceneManager.LoadScene("CutsceneInicial");
    }

    public void ButtomCreditos()
    {
        canvasCreditos.SetActive(true);
        buttomInicia.SetActive(false);
        buttomCreditos.SetActive(false);
        buttomSair.SetActive(false);
        lendoCreditos = true;
    }

    public void ButtomSair()
    {
        Application.Quit();
    }
}
