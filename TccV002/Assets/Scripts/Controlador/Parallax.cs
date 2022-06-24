using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform    bkg;
    public float        parallaxScale;
    public float        velocidade;
    public Transform    cam;
    private Vector3     camAnterior;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        camAnterior = cam.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float paralax_X = (camAnterior.x - cam.position.x) * parallaxScale;
        float bkgTarget = bkg.position.x + paralax_X;

        Vector3 bkgNewPosition = new Vector3(bkgTarget, bkg.position.y, bkg.position.z);
        bkg.position = Vector3.Lerp(bkg.position, bkgNewPosition, velocidade * Time.deltaTime);

        camAnterior = cam.position;
    }
}
