using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCutscene : MonoBehaviour
{
    public  Animator playerAnimations;
    private ControlaCutscene controlado;
    private Fade fade;
    public  int idAnimacao;
    public  bool    podeClicar;
    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType(typeof(Fade)) as Fade;
        controlado = FindObjectOfType(typeof(ControlaCutscene)) as ControlaCutscene;
        podeClicar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(idAnimacao == 2 && controlado.animaAnda == true)
            Time.timeScale = 0;
        if(idAnimacao == 4 && controlado.animaAnda == true)
            Time.timeScale = 0;

    }

    public void PassaAnimacao(int i)
    {
        idAnimacao = i;
    }

    /*public void AnimaAcontecendo(int startEnd)
    {
        if(startEnd == 0)
        {
            podeClicar = false;
        }

        if(startEnd == 1)
        {
            podeClicar = true;
        }
    }*/
}
