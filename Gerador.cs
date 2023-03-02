using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerador : MonoBehaviour
{

    public GameObject carrosEdrones;
    public GameObject fusca;
    public GameObject moedas;
    public GameObject onibus;
    public Transform transformObject;

    public  bool looping = true;
    public float spawn = 2;
    void Start()
    {
        StartCoroutine(TimingGenerator());
    }
    void Update()
    {
        if (UIscr.distancia < 50)
        {
            spawn = 2;
        }
        else
        {
            spawn = 1;
        }
    }
    //Corrotina e randomizador
    IEnumerator TimingGenerator()
    {     
        while(looping == true)
        {
            int aleatorio = Random.Range(0,4);
            if (aleatorio == 0)
            {
                Instantiate(carrosEdrones, transformObject.position, transformObject.rotation);
            }
            if (aleatorio == 1)
            {
                Instantiate(moedas, transformObject.position, transformObject.rotation);
            }
            if (aleatorio == 2)
            {
                Instantiate(fusca, transformObject.position, transformObject.rotation);
            }
            if (aleatorio == 3 && UIscr.distancia > 50)
            {
                Instantiate(onibus, transformObject.position, transformObject.rotation);
            }
            yield return new WaitForSeconds(spawn);
        }
    }
}