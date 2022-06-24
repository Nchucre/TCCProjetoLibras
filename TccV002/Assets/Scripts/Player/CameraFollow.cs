using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public      bool    cameraPlayer;
    public Transform    player;
    public Vector3      offset;
    private Fade        fade;
    void Start()
    {
        cameraPlayer = true;
        fade = FindObjectOfType(typeof(Fade)) as Fade;
        fade.FadeOut();
    }

    void Update()
    {

    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(cameraPlayer)
        {
        transform.position = player.position + offset;
        }
    }
}
