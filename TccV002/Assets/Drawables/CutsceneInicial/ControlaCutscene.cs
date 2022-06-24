using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlaCutscene : MonoBehaviour
{
    public GameObject   diabo01;
    public  Animator    diaboanima;
    public GameObject   canvasTexto;
    public TMP_Text     texto;
    public bool         animaAnda, fimCutscene;
    private int falas;
    private Fade fade;
    private PlayerCutscene playerCutsceneScript;
    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType(typeof(Fade)) as Fade;
        playerCutsceneScript = FindObjectOfType(typeof(PlayerCutscene)) as PlayerCutscene;
        fade.FadeOut();
        animaAnda = true;
        falas = 0;
        Textos();
        canvasTexto.SetActive(true);
        diabo01.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCutsceneScript.idAnimacao == 1)
        {
            playerCutsceneScript.playerAnimations.SetInteger("idAnima", 1);
            canvasTexto.SetActive(true);
            diabo01.SetActive(true);
            falas = 1;
            Textos();
            animaAnda = true;
        }

        if(playerCutsceneScript.idAnimacao == 3)
        {
            playerCutsceneScript.playerAnimations.SetInteger("idAnima", 3);
            canvasTexto.SetActive(true);
            falas = 2;
            Textos();
            animaAnda = true;
        }

        if(playerCutsceneScript.idAnimacao == 5)
        {
            canvasTexto.SetActive(true);
            falas = 3;
            Textos();
            animaAnda = true;
            fimCutscene = true;
        }


        if(Input.GetButtonDown("Fire1"))
        {
            //essa animação tem que começar automaticamente
            if(playerCutsceneScript.idAnimacao == 0 && animaAnda == true)
            {
                Time.timeScale = 1;
                //fade.FadeOut();
                canvasTexto.SetActive(false);
                animaAnda = false;
                
            }

            //essa animação tem que começar automaticamente
            if(playerCutsceneScript.idAnimacao == 2 && animaAnda == true)
            {
                Time.timeScale = 1;
                canvasTexto.SetActive(false);
                animaAnda = false;
            }

            //isso tbm tem que acontecer automaticamente
            if(playerCutsceneScript.idAnimacao == 4 && animaAnda == true)
            {
                Time.timeScale = 1;
                diaboanima.SetBool("anda", true);
                canvasTexto.SetActive(false);
                animaAnda = false;
            }

            if(fimCutscene)
            {
                SceneManager.LoadScene("Nono01");
            }


        }
    }

    public void Textos()
    {
        if(falas == 0)
        {
            texto.text = "Quando acordei estava em um rio de sangue, com dor e sem saber onde estava. \n Não sabia o que fazer então comecei a andar e andei até encontrar algo que me fez entender onde eu estava\n\nClique para continuar";
        }

        if(falas == 1)
        {
            texto.text = "Era um demonio... \nMe contou que eu estava no inferno e que tinha morrido ao bater o carro bebado\nE depois disse algo que me desesperou, que eu havia matado minha mulher no acidente\n\nClique para continuar";
        }

        if(falas == 2)
        {
            texto.text = "Tentei ir atras dela. O demonio me disse que nesse momento eu estava no setimo circulo e que ela devia estar no segundo\nPois pecou na luxuria de me amar tanto que andou comigo bebado sem se importar\n\nClique para continuar";
        }

        if(falas == 3)
        {
            texto.text = "Quando comecei a correr para ir para minha amada o demonio me segurou e disse\n- Calma lá, vai ser divertido te ver sofrer fazendo esse caminho\nentão vou te jogar la pro final do inferno assim me divirto mais hahaha\n\n Então um portal se abriu e o demonio me jogou la dentro\n\nClique para continuar";
        }
    }

    public void VoltaTempo()
    {
        Time.timeScale = 1;
    }


    IEnumerator TempoTexto()
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(10);
        VoltaTempo();
    }
}
