using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Yeni Esya", menuName = "Envanter/Esya")]
public class Esya : ScriptableObject
{
    public string isim = "Yesi Esya";
    public Sprite ikon = null;
    public bool toplandiMi = false;



    public virtual void Kullan()
    {
        // Esyayi kullanir bisi olur

        Debug.Log(isim + " Esya Kullaniliyor ");




    }
}
