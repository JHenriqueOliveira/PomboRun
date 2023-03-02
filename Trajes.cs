using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Trajes : MonoBehaviour
{
    public static float trajepadrao;
    public static float trajevivo;
    public static float trajesamurai;
    public static bool trajessamurai;
    public static bool trajesvivo;
    public static bool trajespadrao = true;
    public GameObject compraIndisponivelsamurai;
    public GameObject compraDisponivelsamurai;
    public GameObject compraIndisponivelvivo;
    public GameObject compraDisponivelvivo;
    public GameObject equiparpadrao;
    public GameObject equiparsamurai;
    public GameObject equiparvivo;
    public GameObject equipadopadrao;
    public GameObject equipadosamurai;
    public GameObject equipadovivo;
    public GameObject traje1;
    public GameObject traje2;
    public GameObject traje3;
    public GameObject vivo;
    public GameObject samurai;
    public GameObject padrao;

    void Start()
    {
        

        traje1.SetActive(true);
        traje2.SetActive(false);
        traje3.SetActive(false);


        
        if (trajevivo > 0 && trajesvivo == false)
        {
            equipadovivo.SetActive(false);
            compraDisponivelvivo.SetActive(false);
            compraIndisponivelvivo.SetActive(false);
            equiparvivo.SetActive(true);
        }
        else if (trajevivo < 0 && trajesvivo == false)
        {
            equipadovivo.SetActive(false);
            equipadovivo.SetActive(false);
            equiparsamurai.SetActive(false);
            if (UIscr.moedajogo >= 100)
            {
                compraDisponivelvivo.SetActive(true);
                compraIndisponivelvivo.SetActive(false);
            }
            else
            {
                compraDisponivelvivo.SetActive(false);
                compraIndisponivelvivo.SetActive(true);
            }
        }
        else if (trajesvivo == true)
        {
            compraDisponivelvivo.SetActive(false);
            compraIndisponivelvivo.SetActive(false);
            equipadovivo.SetActive(true);
            equiparvivo.SetActive(false);
        }

        if (trajesamurai > 0 && trajessamurai == false)
        {
            equipadosamurai.SetActive(false);
            compraDisponivelsamurai.SetActive(false);
            compraIndisponivelsamurai.SetActive(false);
            equiparsamurai.SetActive(true);
        }
        else if (trajesamurai < 0 && trajessamurai == false) 
        {
            equipadosamurai.SetActive(false);
            equipadopadrao.SetActive(false);
            equiparsamurai.SetActive(false);
            if (UIscr.moedajogo >= 100)
            {
                compraDisponivelsamurai.SetActive(true);
                compraIndisponivelsamurai.SetActive(false);
            }
            else
            {
                compraDisponivelsamurai.SetActive(false);
                compraIndisponivelsamurai.SetActive(true);
            }
        }
        else if(trajessamurai == true)
        {
            compraDisponivelsamurai.SetActive(false);
            compraIndisponivelsamurai.SetActive(false);
            equipadosamurai.SetActive(true);
            equiparsamurai.SetActive(false);
        }

    }
    public void Comprarvivo()
    {
        if (UIscr.moedajogo >= 0)
        {
            UIscr.moedajogo = UIscr.moedajogo - 0;
            trajevivo++;
            compraDisponivelvivo.SetActive(false);
            compraIndisponivelvivo.SetActive(false);
            equiparvivo.SetActive(true);
        }
    }
    public void Comprarsamurai()
    {
        if (UIscr.moedajogo >= 0)
        {
            UIscr.moedajogo = UIscr.moedajogo - 0;
            trajesamurai++;
            compraDisponivelsamurai.SetActive(false);
            compraIndisponivelsamurai.SetActive(false);
            equiparsamurai.SetActive(true);
        }
    }
    public  void Equiparsamurai()
    {      
        trajessamurai = true;
        trajesvivo = false;
        trajespadrao = false;
        if (trajevivo > 0)
        {
            equipadovivo.SetActive(false);
            
            equiparvivo.SetActive(true);
        }
        else
        {
            equipadovivo.SetActive(false);
            
            equiparsamurai.SetActive(false);
            if (UIscr.moedajogo >= 100)
            {
                compraDisponivelvivo.SetActive(true);
                compraIndisponivelvivo.SetActive(false);
            }
            else
            {
                compraDisponivelvivo.SetActive(false);
                compraIndisponivelvivo.SetActive(true);
            }
        }     
        equipadopadrao.SetActive(false);
        equiparpadrao.SetActive(true);
        equipadosamurai.SetActive(true);
        equiparsamurai.SetActive(false);
    }
    public void Equiparvivo()
    {
        trajesvivo = true;
        trajessamurai = false;
        trajespadrao = false;

        if (trajesamurai > 0)
        {
            equipadosamurai.SetActive(false);           
            equiparsamurai.SetActive(true);
        }
        else
        {
            equipadosamurai.SetActive(false);
            equipadopadrao.SetActive(false);
            equiparsamurai.SetActive(false);
            if (UIscr.moedajogo >= 100)
            {
                compraDisponivelsamurai.SetActive(true);
                compraIndisponivelsamurai.SetActive(false);
            }
            else
            {
                compraDisponivelsamurai.SetActive(false);
                compraIndisponivelsamurai.SetActive(true);
            }
        }
        equiparvivo.SetActive(false);
        equipadovivo.SetActive(true);
        equipadopadrao.SetActive(false);
        equiparpadrao.SetActive(true);
    }
    public void Equiparpadrao()
    {
        trajessamurai = false;
        trajesvivo = false;
        trajespadrao = true;
        trajepadrao++;
        if (trajesamurai > 0)
        {
            equipadosamurai.SetActive(false);

            equiparsamurai.SetActive(true);
        }
        else
        {
            equipadosamurai.SetActive(false);
          
            equiparsamurai.SetActive(false);
            if (UIscr.moedajogo >= 100)
            {
                compraDisponivelsamurai.SetActive(true);
                compraIndisponivelsamurai.SetActive(false);
            }
            else
            {
                compraDisponivelsamurai.SetActive(false);
                compraIndisponivelsamurai.SetActive(true);
            }
        }
        if (trajevivo > 0)
        {
            equipadovivo.SetActive(false);

            equiparvivo.SetActive(true);
        }
        else
        {
            equipadovivo.SetActive(false);
           
            equiparsamurai.SetActive(false);
            if (UIscr.moedajogo >= 100)
            {
                compraDisponivelvivo.SetActive(true);
                compraIndisponivelvivo.SetActive(false);
            }
            else
            {
                compraDisponivelvivo.SetActive(false);
                compraIndisponivelvivo.SetActive(true);
            }
        }
        equiparpadrao.SetActive(false);
        equipadopadrao.SetActive(true);       
    }
    public void Padrao()
    {
        traje1.SetActive(true);
        traje2.SetActive(false);
        traje3.SetActive(false);
        vivo.SetActive(false);
        samurai.SetActive(false);
        padrao.SetActive(true);
    }
    public void Samurai()
    {
        traje1.SetActive(false);
        traje2.SetActive(false);
        traje3.SetActive(true);
        vivo.SetActive(false);
        samurai.SetActive(true);
        padrao.SetActive(false);
    }
    public void Vivo()
    {
        traje1.SetActive(false);
        traje2.SetActive(true);
        traje3.SetActive(false);
        vivo.SetActive(true);
        samurai.SetActive(false);
        padrao.SetActive(false);
    }
}