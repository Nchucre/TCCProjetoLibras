using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum MaquinaEstado
{
    JOGANDO, PAUSADO, LIVRO, DIALOGANDO, PUZZLE
}
public class Controlador : MonoBehaviour
{
    public      MaquinaEstado   estadoAtual, estadoTemp;
    //private     string          estadoTemp;
    public      PlayerMove      playerScript;
    public      Poder           poderScript;
    public      MsgMundo        morte;
    public      GameObject      canvasDialogo;
    
    //variaveis para controlar a barra de HP
    [Header("Variaveis HP")]
    public      Image[]         HpBar;
    public      Sprite          meiaBarra, barra;
    public      float           percentualHp, hp, hpatual;
    //tive que colocar o HP no controlador pq não lia o HP quando passava fase

    //variaveis de poder
    [Header("Variaveis Poderes")]
    public      GameObject[]      circulo;
    public      Image[]         PoderSelec;
    public      Image[]         EscudoSelec;
    public      GameObject[]      poder;
    public      GameObject[]      escudo;
    public      bool[]          poderes;
    public      bool[]          escudos;
    public      bool[]          poderesPassivos;
    public      int             idPoder, idPoderAtual, quantPoderes, quantEscudos, idEscudo, idEscudoAtual;
    public     int             dano;

    //VARIAVEIS DE MENU
    [Header("Paineis de pause")]
    public      bool            possuiLivro = false;
    public      GameObject      telaPause; 
    public      GameObject      telaLivro;
    public      GameObject      telaStatus;
    public      GameObject      buttomLivro;

    //variaveis menu status
    public      TMP_Text        textoVida, textoVidaAtual, textoDuploPulo, textoVidasExtras, textoQtdVidas;
    public      Image[]         ImagemPoderes;

    void Start()
    {
        //hp = 100;
        hpatual = hp;
        playerScript = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;
        morte        = FindObjectOfType(typeof(MsgMundo)) as MsgMundo;
        poderScript  = FindObjectOfType(typeof(Poder)) as Poder;
        //fade = FindObjectOfType(typeof(Fade)) as Fade;
        //fade.FadeOut();
        telaPause.SetActive(false);
        telaLivro.SetActive(false);
        telaStatus.SetActive(false);
       
        /*if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(gameObject);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        BarrasHp();
        TrocarRapida();
        PoderesSelecionados();

        if(Input.GetButtonDown("Cancel") && estadoAtual != MaquinaEstado.LIVRO)
        {
            PauseGame();
        }
        /*if(estadoAtual != MaquinaEstado.JOGANDO)
        {
            Time.timeScale = 0.0001f;
        }
        else{
            Time.timeScale = 1;
        }*/
    }

    void TrocarRapida()
    {
        //troca de poderes de ataque
        if(quantPoderes <= 1)
        {

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                if(idPoder <= 0)
                {
                    idPoder = 0;
                    idPoderAtual = idPoder;
                }
                else
                {
                    idPoder --;
                    idPoderAtual = idPoder;
                }
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                if(idPoder >= quantPoderes - 1)
                {
                    idPoder = quantPoderes - 1;
                    idPoderAtual = idPoder;
                }
                else
                {
                    idPoder ++;
                    idPoderAtual = idPoder;
                }
            }
        }

        //troca de escudos
        if(quantEscudos <= 1)
        {

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                if(idEscudo <= 0)
                {
                    idEscudo = 0;
                    idEscudoAtual = idEscudo;
                }
                else
                {
                    idEscudo--;
                    idEscudoAtual = idEscudo;
                }
            }

            if(Input.GetKeyDown(KeyCode.V))
            {
                if(idEscudo >= quantEscudos -1)
                {
                    idEscudo = quantEscudos - 1;
                    idEscudoAtual = idEscudo;
                }
                else
                {
                    idEscudo++;
                    idEscudoAtual = idEscudo;
                }
            }
        }

    }

    void BarrasHp()
    {
        percentualHp = hpatual / hp;

        foreach(Image img in HpBar)
        {
            img.enabled = true;
            img.sprite = barra;
        }

        if(percentualHp == 1)
        {

        }
        else if (percentualHp >= 0.9f)
        {
            HpBar[4].sprite = meiaBarra;
        }
        else if (percentualHp >= 0.8f)
        {
            HpBar[4].enabled = false;
        }
        else if (percentualHp >= 0.7f)
        {
            HpBar[3].sprite = meiaBarra;
            HpBar[4].enabled = false;
        }
        else if (percentualHp >= 0.6f)
        {
            HpBar[3].enabled = false;
            HpBar[4].enabled = false;
        }
        else if (percentualHp >= 0.5f)
        {
            HpBar[2].sprite = meiaBarra;
            HpBar[3].enabled = false;
            HpBar[4].enabled = false;
        }
        else if (percentualHp >= 0.4f)
        {
            HpBar[2].enabled = false;
            HpBar[3].enabled = false;
            HpBar[4].enabled = false;
        }
        else if (percentualHp >= 0.3f)
        {
            HpBar[1].sprite = meiaBarra;
            HpBar[2].enabled = false;
            HpBar[3].enabled = false;
            HpBar[4].enabled = false;
        }
        else if (percentualHp >= 0.2f)
        {
            HpBar[1].enabled = false;
            HpBar[2].enabled = false;
            HpBar[3].enabled = false;
            HpBar[4].enabled = false;
        }
        else if (percentualHp > 0)
        {
            HpBar[0].sprite = meiaBarra;
            HpBar[1].enabled = false;
            HpBar[2].enabled = false;
            HpBar[3].enabled = false;
            HpBar[4].enabled = false;
        }
        else if (percentualHp <= 0f)
        {
            HpBar[0].enabled = false;
            HpBar[1].enabled = false;
            HpBar[2].enabled = false;
            HpBar[3].enabled = false;
            HpBar[4].enabled = false;
            //morte.StartCoroutine("Morte");
        }

    }

    void PoderesSelecionados() //muda o poder selecionado no HUD
    {
        //para ataque
        foreach(Image img in PoderSelec)
            {
                img.enabled = false;
            }
        if(quantPoderes == 0)
        {
            foreach(Image img in PoderSelec)
            {
                img.enabled = false;
            }   
        }
        else{
            if(idPoder == 0 && poderes[0] == true) //PODER DE FOGO
            {
                dano = 20;
                PoderSelec[0].enabled = true;
            }
            if(idPoder == 1 && poderes[1] == true) //PODER DE VENTO
            {
                dano = 10;
                PoderSelec[0].enabled = false;
                PoderSelec[1].enabled = true;
            }
        }

        //para o especial, depois tem que fazer um array igual a poderes e escudos
        if(poderes[2] == true)
        {
            circulo[1].SetActive(true);
            if(poderScript.especial)
            {   
                PoderSelec[2].enabled = true;
            }
            else{
                PoderSelec[2].enabled = false;
            }
        }

        //para escudos
        if(quantEscudos > 0)
        {
            foreach(Image img in EscudoSelec)
                {
                    img.enabled = false;
                }   
            if(quantEscudos == 0)
            {
                foreach(Image img in EscudoSelec)
                {
                    img.enabled = false;
                }
            }
            else
            {
                if(poderScript.def)
                {
                    if(idEscudo == 0 && escudos[0] == true) //ESCUDO DE AGUA
                    {
                        EscudoSelec[0].enabled = true;
                        circulo[0].SetActive(true);
                    }
                    if(idEscudo == 1 && escudos[1] == true)
                    {
                        EscudoSelec[1].enabled = true;
                        EscudoSelec[0].enabled = false;
                    }
                }
                else{
                    foreach(Image img in EscudoSelec)
                    {
                        img.enabled = false;
                    }
                }
            }
        }
    }

    public void PauseGame()
    {
        if(possuiLivro == false)
        {
            buttomLivro.SetActive(false);
        }
        else{
            buttomLivro.SetActive(true);
        }
        bool    pauseEstado = telaPause.activeSelf; //crio uma variavel pro estado pausado ou não pausado que recebe a tela
        pauseEstado = !pauseEstado; //sempre que chamar essa função o estado vai inverter
        telaPause.SetActive(pauseEstado); //a variavel de estado vai definir a ativação da tela


        if(pauseEstado)
        {
            Time.timeScale = 0;
            estadoTemp = estadoAtual;
            MudarMaquinaEstado(MaquinaEstado.PAUSADO);
        }
        else if(!pauseEstado)
        {
            Time.timeScale = 1;
            if(estadoTemp != MaquinaEstado.PUZZLE)
            {
                MudarMaquinaEstado(MaquinaEstado.JOGANDO);
            }
            else
            {
                estadoTemp = estadoAtual;
                MudarMaquinaEstado(MaquinaEstado.PUZZLE);
            }
        }

        //agora comandos pra parar o jogo quando estiver nessa tela de pause
        /*switch(pauseEstado)
        {
            case true:
                Time.timeScale = 0; //o tempo no jogo para
                MudarMaquinaEstado(MaquinaEstado.PAUSADO);
            break;
            case false:
                Time.timeScale = 1;//essa variavel do sistema so vai de zero, parado, a um, normal, mais que isso acelera o jogo
                MudarMaquinaEstado(MaquinaEstado.JOGANDO);
            break;
        }*/
    }

    public void LendoStatus()
    {

        textoVida.text = hp.ToString();
        textoVidaAtual.text = hpatual.ToString();
        foreach(Image img in ImagemPoderes)
            {
                img.enabled = false;
            }
        
        //ativa a imagem de fogo no menu
        if(poderes[0] == true)
        {
            ImagemPoderes[0].enabled = true;
        }
        //ativa a imagem de vento no menu
        if(poderes[1] == true)
        {
            ImagemPoderes[1].enabled = true;
        }
        //ativa a imagem do escudo de agua no menu
        if(escudos[0] == true)
        {
            ImagemPoderes[2].enabled = true;
        }
        //ativa a imagem do raio no menu
        if(poderes[2] == true)
        {
            ImagemPoderes[3].enabled = true;
        }

        if(poderesPassivos[0] == true)
        {
            textoDuploPulo.text = "Duplo Pulo";
        }

        if(SceneManager.GetActiveScene().name == "Nono03")
        {
            if(poderesPassivos[1] == false)
                textoVidasExtras.enabled = false;
            if(poderesPassivos[1] == true)
            {
                textoVidasExtras.enabled = true;
                textoQtdVidas.text = "+20";
            }
        }
    }

    //FUNÇÕES DOS BOTÕES DO MENU
    public void ButtomLivro()
    {
        telaPause.SetActive(false);
        telaLivro.SetActive(true);
        MudarMaquinaEstado(MaquinaEstado.LIVRO);
        Time.timeScale = 0;
    }

    public void ButtomStatus()
    {
        LendoStatus();
        telaPause.SetActive(false);
        telaStatus.SetActive(true);
        MudarMaquinaEstado(MaquinaEstado.LIVRO);
        Time.timeScale = 0;
    }

    public void ButtomSair()
    {
        Application.Quit();
    }

    public void ButtomEsc()
    {
        telaLivro.SetActive(false);
        telaStatus.SetActive(false); 
        telaPause.SetActive(true);
        MudarMaquinaEstado(MaquinaEstado.PAUSADO);
        //Time.timeScale = 0;
    }

    //maquina de estado
    public void MudarMaquinaEstado(MaquinaEstado  novoEstado)
    {
        estadoAtual = novoEstado;
    }
}