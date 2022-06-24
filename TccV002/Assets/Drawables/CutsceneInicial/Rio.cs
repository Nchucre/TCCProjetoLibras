using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rio : MonoBehaviour
{
    public GameObject[]     rio;
    private int             passaImagem;
    private bool            podePassar;
    // Start is called before the first frame update
    void Start()
    {
        rio[0].SetActive(true);
        rio[1].SetActive(false);
        rio[2].SetActive(false);
        rio[3].SetActive(false);
        passaImagem = 0;
        podePassar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(podePassar == true)
        {
            PassandoImagem();
        }
    }

    public void PassandoImagem()
    {
        if(passaImagem == 0)
        {
            rio[0].SetActive(true);
            rio[1].SetActive(false);
            rio[2].SetActive(false);
            rio[3].SetActive(false);
            podePassar = false;
            StartCoroutine("PassarRio");
        }
        if(passaImagem == 1)
        {
            rio[0].SetActive(false);
            rio[1].SetActive(true);
            rio[2].SetActive(false);
            rio[3].SetActive(false);
            podePassar = false;
            StartCoroutine("PassarRio");
        }
        if(passaImagem == 2)
        {
            rio[0].SetActive(false);
            rio[1].SetActive(false);
            rio[2].SetActive(true);
            rio[3].SetActive(false);
            podePassar = false;
            StartCoroutine("PassarRio");
        }
        if(passaImagem == 3)
        {
            rio[0].SetActive(false);
            rio[1].SetActive(false);
            rio[2].SetActive(false);
            rio[3].SetActive(true);
            podePassar = false;
            StartCoroutine("PassarRio");
        }
    }

    IEnumerator PassarRio()
    {
        yield return new WaitForSeconds(0.3f);
        passaImagem++;
        podePassar = true;
        if(passaImagem > 3)
            passaImagem = 0;
    }
}
