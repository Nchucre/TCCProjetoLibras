using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poção : MonoBehaviour
{
    private     Controlador     gameControler;
    private     GameObject      nomeGameObject;
    private     float             curaPequena, curaGrande, curaTotal;
    // Start is called before the first frame update
    void Start()
    {
        gameControler = FindObjectOfType(typeof(Controlador)) as Controlador;
        nomeGameObject = this.gameObject;
        curaGrande = 100;
        curaPequena = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interacao()
    {
        if(nomeGameObject.name == "curaGrande" || nomeGameObject.name == "curaGrande01")
        {
            if(gameControler.hpatual < gameControler.hp)
            {
                curaTotal = gameControler.hpatual + curaGrande;
                if(curaTotal > gameControler.hp)
                {
                    gameControler.hpatual = gameControler.hp;
                }
                else
                {
                    gameControler.hpatual = curaTotal;
                }
            }
            Destroy(this.gameObject);
        }

        if(nomeGameObject.name == "curaPequena" || nomeGameObject.name == "curaPequena01")
        {
            if(gameControler.hpatual < gameControler.hp)
            {
                curaTotal = gameControler.hpatual + curaPequena;
                if(curaTotal > gameControler.hp)
                {
                    gameControler.hpatual = gameControler.hp;
                }
                else
                {
                    gameControler.hpatual = curaTotal;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
