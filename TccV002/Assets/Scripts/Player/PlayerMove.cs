using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public  Controlador     gameControlador;
    //Moviventação do player
    [Header("Movimentação")]
    public  float       speed;          //velocidade do personagem
    public Rigidbody2D playerRb;       //para poder usar as funções do rigifbody
    private SpriteRenderer  playerRender;   //pegar o sprite do personagem
    private float       moveX;   //movimentação do personagem
    private float       moveY;
    private Vector2     movimenta;      //vector x,y para movimentar o personagem
    public  float       jumpForce;      //força do pulo
    public  Transform   groundCheck;    //checa a colisão do objeto com o chão
    private bool        noChao;         //depois de checado a colisão esta variavel recebe true ou false
    private bool        pula;           //para facilitar o pulo, saber se está pulando ou não
    private bool        duploPulo;
    public bool        atk;            //para facilitar o atk, saber se está atacando ou não
    public bool        hit;            //pra facilitar o Hit
    private bool        direita = true; //para virar o personagem conforme se anda

    //Variareis de interação com itens e objetos
    [Header("Checagem de interação")]
    public  LayerMask   interagir;
    public  LayerMask   solo; //aqui serve pra gente diferenciar o que está tocando
    public  GameObject  objetoInteracao; //aqui é pra gente SABER o que está tocando com o raycast e pra ter acesso a este objeto
    public  GameObject  alerta;

    //variaveis de knockBack (não funcionou bem)
    [Header("KnockBack")]
    /*public  GameObject  knockBackPreFab;
    public  Transform   knockPosition;*/

    //variaveis de knockback, versão 2 (funcionou)
    private float       knockBack = 8;
    private  float       knockBackMaximo = 0.4f;
    private  float       knockBackContador;
    private  bool        knockBackDireita;

    //Variaveis de Animação
    public  Animator    playerAnimations;
    private int         idAnima;
    public  Color[]     playerFade;

    //variavel de colisão para ver se ta abaixado ou não
    [Header("Colisores")]
    public Collider2D   emPe;
    public Collider2D   morto;
    
    // Start is called before the first frame update
    void Start()
    {
        /*hp = gameControlador.hp;
        hpatual = hp;*/
        playerRb = this.GetComponent<Rigidbody2D>();
        playerAnimations = this.GetComponent<Animator>();
        playerRender = this.GetComponent<SpriteRenderer>();

        gameControlador = FindObjectOfType(typeof(Controlador)) as Controlador;

        playerRender.color = playerFade[0];
        morto.enabled = false;

    }

    void Update()
    {
        if(gameControlador.estadoAtual != MaquinaEstado.JOGANDO)
        {
            /*aqui eu digo que se meu estado de jogo atual for diferente de qualquer coisa
            que não seja o estado JOGANDO o jogo não responde a nenhum comando*/
            if(gameControlador.estadoAtual == MaquinaEstado.DIALOGANDO/*gameControlador.estadoAtual != MaquinaEstado.PUZZLE && gameControlador.estadoAtual != MaquinaEstado.PAUSADO*/)
            {
                if(Input.GetButtonDown("Fire1") && atk == false && objetoInteracao != null)
                {
                    objetoInteracao.SendMessage("interacao", SendMessageOptions.DontRequireReceiver);
                    //esse SENDMENSSAGE é usado pra executar um metodo em outro objeto, no caso o objeto que se está iteragindo
                }
            }
            playerRb.velocity = new Vector2(0,0);
            return;
        }
        Interacao();
        playerAnimations.SetInteger("idAnimation", idAnima);
        playerAnimations.SetBool("grounded", noChao);
        playerAnimations.SetFloat("speedY", playerRb.velocity.y);

        //comando para pular
        if(Input.GetButtonDown("Jump") && noChao == true && atk == false)
        {
            pula = true;
        }

        //mecanica de duplo pulo
        if(Input.GetButtonDown("Jump") && gameControlador.poderesPassivos[0] == true && pula == false && duploPulo == false)
        {
            pula = true;
            duploPulo = true;
        }
        if(noChao == true)
        {
            duploPulo = false;
        }

        //comando para atacar
        if(Input.GetButtonDown("Fire1") && atk == false && objetoInteracao == null)
        {
            playerAnimations.SetTrigger("atk");
        }

        if(gameControlador.poderes[2] == true)
        {
            if(Input.GetButtonDown("Fire3"))
            {
                playerAnimations.SetTrigger("atk");
            }
        }

        //comando para interagir
        if(Input.GetButtonDown("Fire1") && atk == false && objetoInteracao != null)
        {
            objetoInteracao.SendMessage("interacao", SendMessageOptions.DontRequireReceiver);
            //esse SENDMENSSAGE é usado pra executar um metodo em outro objeto, no caso o objeto que se está iteragindo
        }

        if(gameControlador.hpatual <= 0) 
        {
            //gameControlador.hpatual = 0;
            idAnima = 2;
            pula = false;
            morto.enabled = true;
            emPe.enabled = false;
        }

    }

    void FixedUpdate()
    {
        if(gameControlador.estadoAtual != MaquinaEstado.JOGANDO)
        {
            /*aqui eu digo que se meu estado de jogo atual for diferente de qualquer coisa
            que não seja o estado JOGANDO o jogo não responde a nenhum comando*/
            playerRb.velocity = new Vector2(0,0);
            return;
        }
        if(gameControlador.hpatual > 0)
        {
            noChao = Physics2D.OverlapCircle(groundCheck.position, 0.02f, solo);

            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");

            if(moveX > 0 && direita == false && atk == false)
            {
                Vira();
            }
            else if(moveX < 0 && direita == true && atk == false)
            {
                Vira();
            }

            if(knockBackContador <= 0)
            {
            //essas duas linhas abaixo movimentam o player, isso não muda nunca
                movimenta = new Vector2(moveX * speed, playerRb.velocity.y);
                playerRb.velocity = movimenta;  
            } else {
                if(knockBackDireita)
                {
                    playerRb.velocity = new Vector2(-knockBack, knockBack/2);
                }
                if(!knockBackDireita)
                {
                    playerRb.velocity = new Vector2(knockBack, knockBack/2);
                }
                knockBackContador -= Time.deltaTime;
            }




                //IF para trocar a animação ao andar  
                if(moveX != 0)
                {
                    idAnima = 1;
                }
                else // Se não estiver andando seta a animação parado
                {
                    idAnima = 0;
                }

                //aqui faz o personagem pular, a animação de pulo é feita pelo Unity
                if(pula == true)
                {
                    playerRb.AddForce(new Vector2(0, jumpForce));
                    pula = false;
                }

                if(atk == true && noChao == true)
                {
                    playerRb.velocity = new Vector2(0,playerRb.velocity.y);
                }

                //teste pra tentar fazer ele cair mais rapido
                if(playerRb.velocity.y < 0)
                {
                    //Debug.Log(playerRb.velocity.y);
                    float caiRapido = playerRb.velocity.y * 1.05f;
                    playerRb.velocity = new Vector2(playerRb.velocity.x, caiRapido);
                }
        }
        else
        {
            playerRb.velocity = new Vector2(0,playerRb.velocity.y);
        }
    }

    void Vira()
    {
        direita = !direita; //inverte o sinal do personagem sempre que chamarmos essa função
        transform.Rotate(0f, 180f, 0f);
    }

    public void Atacando(int atacando)
    {
        switch (atacando)
        {
            case 0:
                atk = false;
                break;
            case 1:
                atk = true;
                break;
        }
    }

    void Interacao()
    {
        RaycastHit2D rangeInteracao = Physics2D.Raycast(transform.position, transform.right, 1f, interagir);
        Debug.DrawRay(transform.position, transform.right * 1f, Color.red);

        if(rangeInteracao)
        {
            objetoInteracao = rangeInteracao.collider.gameObject;
            alerta.SetActive(true);
        }
        else{
            objetoInteracao = null;
            alerta.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if(colisor.gameObject.CompareTag("Inimigo"))
        {
            if(gameControlador.hpatual > 0)
            {
                if(hit == false)
                {
                hit = true;
                atk = false;
                gameControlador.hpatual-=10;
                playerAnimations.SetTrigger("hit");
                //tentativa 2 de knockback
                knockBackContador = knockBackMaximo;
                if(colisor.transform.position.x < transform.position.x)
                {
                    knockBackDireita = false;
                }
                if(colisor.transform.position.x > transform.position.x)
                {
                    knockBackDireita = true;
                }
                /*playerRb.AddForce(transform.up * 5, ForceMode2D.Impulse);
                playerRb.AddForce(transform.right * 100, ForceMode2D.Impulse);
                //playerRb.simulated = false;
                
                
                /*GameObject knockTemporario = Instantiate(knockBackPreFab, knockPosition.position, knockPosition.localRotation);
                Destroy(knockTemporario, 0.03f);*/

                StartCoroutine("Ivuneravel");
                }
            }
            else if(gameControlador.hpatual <= 0)
            {
                idAnima = 2;
                pula = false;
                morto.enabled = true;
                emPe.enabled = false;
            }
        }
    }
    /*void OnCollisionExit2D(Collision2D colisor)
    {
        if(colisor.gameObject.CompareTag("Inimigo"))
        {
            hit = false;
        }
    }*/

    IEnumerator Ivuneravel()
    {
        playerRender.color = playerFade[1];
        yield return new WaitForSeconds(0.2f);
        playerRender.color = playerFade[0];
        yield return new WaitForSeconds(0.2f);
        //playerRb.simulated = true;
        playerRender.color = playerFade[1];
        yield return new WaitForSeconds(0.2f);
        playerRender.color = playerFade[0];
        yield return new WaitForSeconds(0.2f);
        playerRender.color = playerFade[1];
        yield return new WaitForSeconds(0.2f);
        playerRender.color = playerFade[0];
        hit = false;
    }
}
