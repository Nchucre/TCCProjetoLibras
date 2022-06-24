using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SobeMão : MonoBehaviour
{
    public  Animator    giganteAnimator;
    private PlayerMove  playerScript;
    private Fade        fade;
    private Controlador gameControler;
    public  Collider2D  colisorMao;
    private bool subiu;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;
        gameControler = FindObjectOfType(typeof(Controlador)) as Controlador;
        fade = FindObjectOfType(typeof(Fade)) as Fade;
        colisorMao.enabled = true;
        subiu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(subiu)
        {
            StartCoroutine("Sobe");
        }
        
    }

    public void OnCollisionEnter2D(Collision2D colisor)
    {
        if(colisor.gameObject.CompareTag("Player") && subiu == false)
        {
            //fade.FadeIn();
            subiu = true;
            giganteAnimator.SetTrigger("PlayerSubiu");
            StartCoroutine("AtivarFade");
            //StartCoroutine("Sobe");
            //colisor.transform.position = new Vector3(playerScript.transform.position.x, playerScript.transform.position.y + 1, playerScript.transform.position.z);
            //colisor.rigidbody.AddForce(new Vector2 (0, 3));
        }
    }

    IEnumerator Sobe()
    {
        yield return new WaitForSeconds(0.1f);
        playerScript.transform.position = new Vector3(playerScript.transform.position.x, playerScript.transform.position.y + 0.3f, playerScript.transform.position.z);
        //yield return new WaitForSeconds(0.1f);
    }

    IEnumerator AtivarFade()
    {
        yield return new WaitForSeconds(0.2f);
        fade.FadeIn();
        StartCoroutine("FimdeJogo");
    }

    IEnumerator FimdeJogo()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
