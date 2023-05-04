using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvanterUI : MonoBehaviour
{
    public Transform esyalarEbeveyn;

    public GameObject slotPrefab;

    Envanter envanter;

    //SlotEnvanter[] slotlar;

    private float amountOfDrag;
    public float sensitivity;
    public int itemNo = 0;

    public List<SlotEnvanter> slotlar = new List<SlotEnvanter>();

    GirisKarakter giris;

    public Karakter karakter;

    void Start()
    {
        envanter = Envanter.ornek;
        envanter.esyaDegistigindeGeriCagir += UpdateUI;

        //slotlar = esyalarEbeveyn.GetComponentsInChildren<SlotEnvanter>();

        giris = FindObjectOfType<GirisKarakter>();
    }


    void UpdateUI()
    {

        for (int i = 0; i < envanter.esyalar.Count; i++)
        {
            if (i < slotlar.Count)
            {
                slotlar[i].EsyaEkle(envanter.esyalar[i]);
            }
            else if(envanter.esyalar[i])   // envanterdeki esyalar slottan fazlaysa, yeni slot ekleyip yeni itemi oraya atýyor,  bu sistem ileride sadece yeni slot eklemek istedigimizde eklencek
            {
                SlotEkle();
                slotlar[i].EsyaEkle(envanter.esyalar[i]);
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

            if (itemNo < slotlar.Count-1 && slotlar.Count >= 2) // Slottaki itemi secer sagini ya da solundaki itemi birakir , if (itemNo < envanter.bosYer - 1 && slotlar.Count >= 2)
            {
                itemNo++;

                slotlar[itemNo-1].EsyayiTerket();                
                slotlar[itemNo].EsyayiSec();
                karakter.EsyaKullan(envanter.esyalar[itemNo]);
            }
        }

        if (amountOfDrag <= -sensitivity)
        {
            amountOfDrag = 0;
            if (itemNo > 0 && slotlar.Count>= 2)
            {
                itemNo--;

                slotlar[itemNo + 1].EsyayiTerket();
                slotlar[itemNo].EsyayiSec();
                karakter.EsyaKullan(envanter.esyalar[itemNo]);
            }
        }
    }

    public void SlotEkle() // envantere yeni slot ekler
    {
        GameObject yeniSlot = Instantiate(slotPrefab,esyalarEbeveyn);

        slotlar.Add(yeniSlot.GetComponentInChildren<SlotEnvanter>());

        
    }


}
