using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystemEscudoAgua : MonoBehaviour
{
    private     WinEscudoAgua   win;
    private     Fade            fade;
    public      GameObject      formaCorreta;
    private     bool            movendo;
    private     float           startPosX, startPosY;
    private     Vector3         resetPosition;
    void Start()
    {
        resetPosition = this.transform.localPosition;
        fade = FindObjectOfType(typeof(Fade)) as Fade;
        win = FindObjectOfType(typeof(WinEscudoAgua)) as WinEscudoAgua;
        fade.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        if(movendo)
        {
            Vector3 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);

            this.gameObject.transform.localPosition = new Vector3(mousepos.x - startPosX, mousepos.y - startPosY, this.gameObject.transform.localPosition.z);
        }
        
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);

            startPosX = mousepos.x - this.transform.localPosition.x;
            startPosY = mousepos.y - this.transform.localPosition.y;

            movendo = true;
        }
    }

    private void OnMouseUp()
    {
        movendo = false;

        if(Mathf.Abs(this.transform.position.x - formaCorreta.transform.position.x) <= 0.2f &&
            Mathf.Abs(this.transform.position.y - formaCorreta.transform.position.y) <=0.2f)
            {
                this.transform.position = new Vector3(formaCorreta.transform.position.x,
                                                            formaCorreta.transform.position.y,
                                                            formaCorreta.transform.position.z);

                win.AddPontosPulo();
            }
            else
            {
                this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
            }

    }
}
