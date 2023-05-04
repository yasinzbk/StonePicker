using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvanterUI : MonoBehaviour
{
    public Transform esyalarEbeveyn;

    Envanter envanter;

    SlotEnvanter[] slotlar;

    private float amountOfDrag;
    public float sensitivity;
    public int itemNo = 0;


    GirisKarakter giris;
    void Start()
    {
        envanter = Envanter.ornek;
        envanter.esyaDegistigindeGeriCagir += UpdateUI;

        slotlar = esyalarEbeveyn.GetComponentsInChildren<SlotEnvanter>();

        giris = FindObjectOfType<GirisKarakter>();
    }


    void UpdateUI()
    {
        Debug.Log("UI guncellendi");
        for (int i = 0; i < slotlar.Length; i++)
        {
            if (i < envanter.esyalar.Count)
            {
                slotlar[i].EsyaEkle(envanter.esyalar[i]);
            }
            else
            {
                slotlar[i].SlotuTemizle();
            }
        }

    }

    void Update()
    {
        SlotDegis();
    }

    void SlotDegis()  // fare tekerlegi ile envanter slotunu degistirir
    {
        var scroll = giris.fareTekerlegi;

        amountOfDrag += scroll;

        if (amountOfDrag >= sensitivity)
        {
            amountOfDrag = 0;

            if (itemNo < envanter.bosYer - 1) // control item count in inventory
            {
                itemNo++;
                slotlar[itemNo-1].EsyayiTerket();
                slotlar[itemNo].EsyayiSec();
            }
        }

        if (amountOfDrag <= -sensitivity)
        {
            amountOfDrag = 0;
            if (itemNo > 0)
            {
                itemNo--;
                slotlar[itemNo + 1].EsyayiTerket();
                slotlar[itemNo].EsyayiSec();

            }
        }
    }


}
