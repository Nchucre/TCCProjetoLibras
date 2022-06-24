using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoAgua : MonoBehaviour
{
    private PlayerMove playerPos;
    void Start()
    {
        playerPos = FindObjectOfType(typeof(PlayerMove)) as PlayerMove;
        this.transform.position = playerPos.transform.position;
        StartCoroutine("DesativaEscudo");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.transform.position;
    }

    IEnumerator DesativaEscudo()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
