using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogos : MonoBehaviour
{
    private  string         nomeCena;
    private  Controlador    gameControler;
    public  GameObject      canvasDialogo;
    public  TMP_Text        caixaTexto;
    public  bool[]          idConversa, idJaFalou;
    private int             idfala;
    //private bool            falando;
    //public  string[]        falas;
    // Start is called before the first frame update
    void Start()
    {
        idfala = 0;
        gameControler = FindObjectOfType(typeof(Controlador)) as Controlador;
        nomeCena = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    { 
        //primeiro dialogo, vencendo puzzle de fogo
        if(gameControler.poderes[0] == true && idConversa[0] == false)
        {
            idConversa[0] = true;
            FalasDeVitoria();
        }

        //segundo dialogo, vencendo duplo pulo
        if(gameControler.poderesPassivos[0] == true && idConversa[1] == false)
        {
            idConversa[1] = true;
            FalasDeVitoria();
        }

        //vencendo o vento
        if(gameControler.poderes[1] == true && idConversa[2] == false)
        {
            idConversa[2] = true;
            if(idfala == 0)
                FalasDeVitoria();
        }

        //vencendo o escudo de agua
        if(gameControler.escudos[0] == true && idConversa[3] == false)
        {
            idConversa[3] = true;
            if(idfala == 0)
                FalasDeVitoria();
        }

        //vencendo o raio
        if(gameControler.poderes[2] == true && idConversa[4] == false)
        {
            idConversa[4] = true;
            if(idfala == 0)
                FalasDeVitoria();
        }

        //Vencendo a primeira Vida extra
        if(gameControler.poderesPassivos[1] == true && idConversa[5] == false)
        {
            idConversa[5] = true;
            if(idfala == 0)
                FalasDeVitoria();
        }
    }

    public void FalasDeVitoria()
    {
        //primeiro dialogo, vencendo puzzle de fogo
            if(idConversa[0] == true && idJaFalou[0] == false)
            {
                caixaTexto.text = "Você adquiriu o poder de fogo, clique no lado ESQUERDO do mouse para usar";
                StartCoroutine("DialogoVenceu");
                idJaFalou[0] = true;
            }

            //vencendo o duplo pulo
            if(idConversa[1] == true && idJaFalou[1] == false)
            {
                caixaTexto.text = "Você adquiriu o pulo duplo, agora pode apertar o botão de pulo (Espaço) duas vezes para ir mais alto ou mais longe";
                StartCoroutine("DialogoVenceu");
                idJaFalou[1] = true;
            }
        
            //vencendo o puzzle de vento
            if(idConversa[2] == true && idJaFalou[2] == false)
            {
                if(idfala == 0)
                {
                    StartCoroutine("DialogoAnda");
                    caixaTexto.text = "Você adquiriu o poder do vento";
                }

                if(idfala == 1)
                {
                StartCoroutine("DialogoAnda");
                    caixaTexto.text = "Aperte Q ou E para alternar entre os poderes";
                }

                if(idfala == 2)
                {
                    StartCoroutine("DialogoAnda");
                    caixaTexto.text = "O poder de vento é menos poderoso que o de fogo, porem seu tamanho ajudará a acertar os inimigos";
                }
                if(idfala > 2 )
                {
                    canvasDialogo.SetActive(false);
                    idfala = 0;
                    idJaFalou[2] = true;
                }
            }

            //vencendo o puzzle de agua
            if(idConversa[3] == true && idJaFalou[3] == false)
            {
                if(idfala == 0)
                {
                    StartCoroutine("DialogoAnda");
                    caixaTexto.text = "Você adquiriu o escudo de agua, clique o lado DIREITO do mouse para utilizar";
                }

                if(idfala == 1)
                {
                    StartCoroutine("DialogoAnda");
                    caixaTexto.text = "O escudo lhe protegera de projeteis e alguns inimigos, mas não todos";
                }

                if(idfala == 2)
                {
                    StartCoroutine("DialogoAnda");
                    caixaTexto.text = "Você não pode usar o escudo o tempo todo, use com sabedoria";
                }
                if(idfala > 2 )
                {
                    canvasDialogo.SetActive(false);
                    idfala = 0;
                    idJaFalou[3] = true;
                }
            }

            //vencendo o puzzle de raio
            if(idConversa[4] == true && idJaFalou[4] == false)
            {
                if(idfala == 0)
                {
                    StartCoroutine("DialogoAnda");
                    caixaTexto.text = "Você adquiriu o poderoso Raio, clique no SHIFT ESQUERDO para utilizar";
                }
                if(idfala == 1)
                {
                    StartCoroutine("DialogoAnda");
                    caixaTexto.text = "O Raio matará qualquer corpo em seu alcance, porém almas não são afetadas";
                }
                if(idfala == 2)
                {
                    StartCoroutine("DialogoAnda");
                    caixaTexto.text = "Devido ao seu grande poder você não poderá usar a todo momento, use com sabedoria";
                }
                if(idfala > 2 )
                {
                    canvasDialogo.SetActive(false);
                    idfala = 0;
                    idJaFalou[4] = true;
                }
            }

            //Vencendo o Primeirp puzzle de vida extra
            if(idConversa[5] == true && idJaFalou[5] == false)
            {
                if(idfala == 0)
                {
                    StartCoroutine("DialogoAnda");
                    caixaTexto.text = "Esta Parede lhe garante vida extra";
                }
                if(idfala == 1)
                {
                    StartCoroutine("DialogoAnda");
                    caixaTexto.text = "Talvez você encontre mais dessas na sua jornada";
                }
                if(idfala > 1)
                {
                    canvasDialogo.SetActive(false);
                    idfala = 0;
                    idJaFalou[5] = true;
                }
            }


    }

    IEnumerator DialogoVenceu()
    {  
        canvasDialogo.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        canvasDialogo.SetActive(false);
    }

    IEnumerator DialogoAnda()
    {
        canvasDialogo.SetActive(true);
        yield return new WaitForSeconds(3f);
        idfala++;
        FalasDeVitoria();
    }
}
