using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorPowerUp : MonoBehaviour
{
    public GameObject cronometro;
    public GameObject dobro;
    public GameObject bomba;
    public Transform transformObject;

    public bool looping = true;
    void Start()
    {
        StartCoroutine(TimingGenerator());
    }
    //Corrotina e randomizador
    IEnumerator TimingGenerator()
    {
        while (looping == true)
        {
            yield return new WaitForSeconds(15);
            int aleatorio = Random.Range(0, 3);
            if (aleatorio == 2)
            {
                Instantiate(cronometro, transformObject.position, transformObject.rotation);
            }
            if (aleatorio == 1)
            {
                Instantiate(dobro, transformObject.position, transformObject.rotation);
            }
        }
    }
}