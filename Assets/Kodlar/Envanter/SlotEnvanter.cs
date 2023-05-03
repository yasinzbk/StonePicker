using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotEnvanter : MonoBehaviour
{

    public Image ikon;

    public Esya esya;


    public void EsyaEkle(Esya yeniEsya)
    {


        esya = yeniEsya;
        ikon.enabled = true;
        ikon.sprite = esya?.ikon;


    }

    public void SlotuTemizle()
    {
        esya = null;
        
        ikon.sprite = null;
        ikon.enabled = false;
    }

    public void EsyayiKullan()
    {

        if (esya != null)
        {
            esya.Kullan();


        }
    }
}
