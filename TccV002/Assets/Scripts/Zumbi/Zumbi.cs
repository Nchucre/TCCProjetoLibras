using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour
{
    private     Controlador     gameControler;
    //variaveis de Hp
    public int     hp;
    private int    hpAtual;
    private float  percentualHp; //pra calcular melhor o dano e a diminuição da barra de hp
    public  GameObject  barrasHp; // objeto contendo todas as barras, pra aparecer so quando levar dano
    public  Transform   barraVidaAtual; //pra poder diminuir a barra de vida
    //variaveis de movimentação
    private Rigidbody2D zumbiRb;
    private float       moveX;
    private Vector2     movimenta;
    private bool        andaPara = false, direita = true, wallHit;
    private Animator    zumbiAnimations;
    //variaveis de checkagem de colisão e etc
    public  Transform   groundCheck;
    public  Transform   wallCheck;
    public  LayerMask   layerCheck;
    //variaveis de knockBack (não funcionou bem)
    public  GameObject  knockBackPreFab;
    public  Transform   knockPosition;
    public  PlayerMove  posicaoPlayer;
    public  float       knockX;
    private float       tempKX;

    //variaveis de knockback versão 2
    

    // Start is called before the first frame update
    void Start()
    {
        gameControler = FindObjectOfType(typeof(Controlador)) as Controlador;
        hp = 60;
        hpAtual = hp;
        barraVidaAtual.localScale = new Vector3(1,1,1);
        zumbiRb = this.GetComponent<Rigidbody2D>();
        zumbiAnimations = this.GetComponent<Animator>();
        moveX = 3;

        posicaoPlayer = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;

        knockPosition.localPosition = new Vector3(knockX, knockPosition.localPosition.y, 0);

        barrasHp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameControler.estadoAtual != MaquinaEstado.JOGANDO)
        {
            /*aqui eu digo que se meu estado de jogo atual for diferente de qualquer coisa
            que não seja o estado JOGANDO o jogo não responde a nenhum comando*/
            zumbiRb.velocity = new Vector2(0,0);
            return;
        }
        RaycastHit2D groundInfodown = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, layerCheck);
        wallHit = Physics2D.OverlapCircle(wallCheck.position, 0.2f, layerCheck);

        if(groundInfodown.collider == false || wallHit == true)
        {
            if(direita == false)
            {
                Flip();
                moveX *= -1;
                KnockFlip();
            }
            else{
                Flip();
                moveX *= -1;
                KnockFlip();
            }
        }
        if(andaPara)
        {
            movimenta = new Vector2(moveX, zumbiAnimations.velocity.y);
            zumbiRb.velocity = movimenta;
        }
        else if(andaPara == false){
            zumbiRb.velocity = new Vector2(0, zumbiRb.velocity.y);
        }

        //mudando a posição do knockback
        KnockFlip();

        if(hpAtual <= 0)
        {
            Destroy(gameObject);
        }

    }
    
    public void Anda(int move)
    {
        switch (move)
        {
            case 0:
                andaPara = false;
            break;
            case 1:
                andaPara = true;
            break;
        }
    }

    void Flip()
    {
        direita = !direita; //inverte o sinal do personagem sempre que chamarmos essa função
        float xScale = this.transform.localScale.x;
        xScale *= -1;
        transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
    }

    void KnockFlip()
    {
        float playerX = posicaoPlayer.transform.position.x;

        if (playerX < transform.position.x)
        {
            tempKX = knockX;
        }
        else if (playerX > transform.position.x)
        {
            tempKX = knockX * -1;
        }
        knockPosition.localPosition = new Vector3(tempKX, knockPosition.localPosition.y, 0);
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        //Debug.Log("Hit");
        if(colisor.gameObject.CompareTag("Poder"))
        {
            barrasHp.SetActive(true);
            int dano = gameControler.dano;//pegando o dano no script da bola de fogo
            
            //calculando o dano
            hpAtual = hpAtual-dano;
            percentualHp = (float)hpAtual/(float)hp;
            if(percentualHp < 0)
            {
                percentualHp = 0;
            }
            //atualizando a barra de HP
            barraVidaAtual.localScale = new Vector3(percentualHp, 1, 1);


            //tentativa dois de knockback
            /*zumbiRb.velocity = Vector2.zero;
            Vector2 forcaKnock = new Vector2(100, 2);
            zumbiRb.AddForce(forcaKnock, ForceMode2D.Impulse);*/


            //tentativa um de knockback
            //criando o knockback
            GameObject knockTemporario = Instantiate(knockBackPreFab, knockPosition.position, knockPosition.localRotation);
            Destroy(knockTemporario, 0.03f);
            //observação: a atualização do motor é feita a cada 0.02segundos então esse tempo garante que vai funcionar

            zumbiAnimations.SetTrigger("Hit");
        }

        /*if(colisor.gameObject.CompareTag("Player"))
        {
            colisor.GetComponent<Rigidbody2D>().AddForce(transform.right * -100, ForceMode2D.Impulse);
        }*/
    }
}
