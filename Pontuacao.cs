using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIscr : MonoBehaviour
{
    public Text textodistancia;
    public Text textomoeda;
    public Text textorecorde;
    public static int moedas;
    public static int moedajogo;
    public static int moedasTotais;
    public static int distancia;
    public Text textomoedajogo;
    public Text moeda;
    int recorde;
    void Start()
    {
        moedas = 0;
        distancia = 0;
        LoadPrefs();
    }
    void Update()
    {
        textorecorde.text = recorde.ToString();
        textomoeda.text = moedas.ToString();
        moeda.text = moedas.ToString();
        textomoedajogo.text = moedajogo.ToString();
        textodistancia.text = distancia.ToString();
        if (distancia > recorde)
        {
            recorde = distancia;
        }
        SavePrefs();
    }
    private void SavePrefs()
    {
        PlayerPrefs.GetInt("recorde", recorde);
        PlayerPrefs.GetInt("moedas", moedajogo);
        PlayerPrefs.SetInt("recorde", recorde);
        PlayerPrefs.SetInt("moedas", moedajogo);    
    }
    private void LoadPrefs()
    {
        recorde = PlayerPrefs.GetInt("recorde");
        moedajogo = PlayerPrefs.GetInt("moedas");
        textorecorde.text = "recorde";
        textomoeda.text = "moedajogo" ;
        textomoedajogo.text = "moedajogo";
    }
}
