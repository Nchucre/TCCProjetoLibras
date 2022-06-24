using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FInalFase : MonoBehaviour
{
    // Start is called before the first frame update
    private Fade fade;
    private string nomeCena;
    void Start()
    {
        fade = FindObjectOfType(typeof(Fade)) as Fade;
        nomeCena = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interacao()
    {
        StartCoroutine("Final");
        //SceneManager.LoadScene(1); caso eu saiba a hierarquia das cenas é possivel usar o numero dela na hierarquia ao inves do nome
    }

    IEnumerator Final()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1f);
        if(nomeCena == "Nono01")
            SceneManager.LoadScene("Nono02");
        if(nomeCena == "Nono02")
        {
            SceneManager.LoadScene("Nono03");
        }
    }
}
