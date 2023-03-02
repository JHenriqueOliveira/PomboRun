using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject samurai;
    public GameObject vivo;
    public GameObject padrao;
    public Transform transformObject;
    void Start()
    {
        if (Trajes.trajessamurai == true)
        {
            Instantiate(samurai, transformObject.position, transformObject.rotation);
        }
        if (Trajes.trajespadrao == true)
        {
            Instantiate(padrao, transformObject.position, transformObject.rotation);
        }
        if (Trajes.trajesvivo == true)
        {
            Instantiate(vivo, transformObject.position, transformObject.rotation);
        }
    }
}