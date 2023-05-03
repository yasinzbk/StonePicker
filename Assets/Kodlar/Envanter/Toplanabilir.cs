using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplanabilir : MonoBehaviour
{

    public Esya esya;


    private void Start()
    {

        //if (esya.toplandiMi)   // sahne yuklenirken toplanmis objeleri siliyordu, buna gerek ollmadigini dusundum
        //{

        //    Destroy(gameObject);
        //}
    }


    public void EsyayiAl()
    {
        Debug.Log(esya.isim + " alindi");
        bool toplandiMi = Envanter.ornek.Ekle(esya);

        if (toplandiMi) 
        {
            esya.toplandiMi = true;

            Destroy(gameObject);

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Karakter")
        {

            EsyayiAl();

        }

    }
}
