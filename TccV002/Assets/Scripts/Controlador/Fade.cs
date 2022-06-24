using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update
    public      GameObject      painelfume;
    public      Image           fume;
    public      Color[]         transicao;
    private     float           step;
    void Start()
    {
        step = 0.03f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        painelfume.SetActive(true);
        StartCoroutine("fadei");
    }

    public void FadeOut()
    {
        StartCoroutine("fadeo");
    }

    IEnumerator fadei()
    {
        for(float i=0; i <=1; i += step)
        {
            fume.color = Color.Lerp(transicao[0], transicao[1], i);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator fadeo()
    {
        yield return new WaitForSeconds(0.5f);
        for(float i=0; i <=1; i += step)
        {
            fume.color = Color.Lerp(transicao[1], transicao[0], i);
            yield return new WaitForEndOfFrame();
        }
        painelfume.SetActive(false);
    }
}
