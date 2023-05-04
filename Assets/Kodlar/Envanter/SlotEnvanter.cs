using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotEnvanter : MonoBehaviour
{

    public Image ikon;

    public Esya esya;

    public GameObject cerceve;

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

    public void EsyayiKullan()  // evet esya kullanmayi yapcam ama bu yontem cok amele yontemi
    {

        if (esya != null)
        {
            switch (esya.nitelik)
            {
                case Esya.EsyaNiteligi.kazma:
                    
                    break;
                case Esya.EsyaNiteligi.toprak:

                    break;

            }


        }
    }

    public void EsyayiSec() //esya seciliyken olacaklar
    {
        cerceve.SetActive(true);
    }

    public void EsyayiTerket()
    {
        cerceve.SetActive(false);
    }
}
