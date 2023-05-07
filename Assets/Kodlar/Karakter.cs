using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{

    public delegate void ElindekiEsyaDegistiginde();
    public ElindekiEsyaDegistiginde elindekiEsyaDegistigindeGeriCagir;

    private GirisKarakter giris;

    public float hareketHizi = 2f;

    public Rigidbody2D RB { get; private set; }
    private Vector2 calismaAlani;
    public Vector2 SuankiHiz { get; private set; }  // karakterin hizina gore farkli eylemler yapildiginda kullanilacak

    float screenWidth = Screen.width;
    public Camera mainCamera;
    //Gecici Alan
    public int yuzununYonu = 1;

    public Esya elindekiEsya;

    public Esya defaultEsya;

    public Weapon kazma;
    public GridKontrol gridKontrol;
    public GameObject el;

    public SesYoneticisi sesYonetim;
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        giris = GetComponent<GirisKarakter>();

        if (elindekiEsya == null)
        {
            EsyaKullan(defaultEsya);

        }

    }
    void Update()
    {
        Hareket();

        Dondur();
    }

    void Hareket()
    {
        XhiziniKur(hareketHizi * giris.girisX);
        YhiziniKur(hareketHizi * giris.girisY);

        //if (giris.girisX != 0 || giris.girisY != 0)
        //{
        //sesYonetim.Oynat("yurume");

        //}
        
    }

    void Dondur()
    {
        Vector3 mousePosition = Input.mousePosition;
        float normalizedX = mousePosition.x / screenWidth;
        Vector3 karakterinEkranKonumu = mainCamera.WorldToScreenPoint(transform.position);

        float normalizedKarX = karakterinEkranKonumu.x / screenWidth;

        if (normalizedX < normalizedKarX)
        {
            // Fare karakterin solunda

            if (yuzununYonu == 1)
            {
                RB.transform.Rotate(0, 180f, 0);
                yuzununYonu = -yuzununYonu;

            }
        }
        else if (yuzununYonu == -1)
        {
            // Fare karakterin saginda
            RB.transform.Rotate(0, 180f, 0);
            yuzununYonu = -yuzununYonu;
        }

    }

    public void XhiziniKur(float hiz)
    {
        calismaAlani.Set(hiz, SuankiHiz.y);
        SonHizKur();
    }

    public void YhiziniKur(float hiz)
    {
        calismaAlani.Set(SuankiHiz.x, hiz);
        SonHizKur();
    }

    private void SonHizKur()
    {
            RB.velocity = calismaAlani;
            SuankiHiz = calismaAlani;
    }


    public void EsyaKullan(Esya esya) // karakter slotttaki secili itemin niteligine sahip olur 
    {
        elindekiEsya = esya;
        //  elindeki objeyi secili objenin sprite ina donustur
        if (elindekiEsyaDegistigindeGeriCagir != null)
        {
            elindekiEsyaDegistigindeGeriCagir.Invoke();
            el.GetComponent<SpriteRenderer>().sprite = esya.ikon;
        }
        switch (esya.nitelik)
            {
                case Esya.EsyaNiteligi.kazma:
                kazma.Kullan();

                    break;
                case Esya.EsyaNiteligi.toprak:
                gridKontrol.Kullan();
                    break;

            }


    }
}
