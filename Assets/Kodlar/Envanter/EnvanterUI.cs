using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvanterUI : MonoBehaviour
{
    public Transform esyalarEbeveyn;

    Envanter envanter;

    SlotEnvanter[] slotlar;


    void Start()
    {
        envanter = Envanter.ornek;
        envanter.esyaDegistigindeGeriCagir += UpdateUI;

        slotlar = esyalarEbeveyn.GetComponentsInChildren<SlotEnvanter>();
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
}
