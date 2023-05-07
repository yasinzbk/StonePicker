using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public float hasar = 10f;

    public Camera mainCamera;
    public LayerMask resourceMask;
    public Karakter karakter;

    public Vector2 characterPosition { get; private set; }

    private GirisKarakter giris;
    private bool kullan; // kalkabilir amele yontemi

    public float yakinMesKarakterin = 5f;

    public bool vurabilirMi;

    Animator anim;

    public SesYoneticisi sesYonetim;

    private void Start()
    {
        giris = GetComponent<GirisKarakter>();
        anim = GetComponent<Animator>();
        karakter.elindekiEsyaDegistigindeGeriCagir += SifirlaKullan;
    }

    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {

        if (kullan)
        {
            giris.FareKonumunuVer();
            Collider2D hitCollider = Physics2D.OverlapPoint(giris.fareKonumu,resourceMask);

            //RaycastHit2D hitCollider = Physics2D.Raycast(giris.FareKonumunuVer(), Vector2.zero);

            if (hitCollider != null && hitCollider.gameObject.tag == "kaynak") // && hitCollider.gameObject.tag == "kaynak"
            {
                characterPosition = transform.position;
                float distanceToResource = Vector2.Distance(characterPosition, hitCollider.transform.position);

                Kaynak hedef = hitCollider.gameObject.GetComponent<Kaynak>();

                if (distanceToResource < yakinMesKarakterin)
                {
                    

                    hedef.CerceveAc();

                    if (giris.saldiri && vurabilirMi)
                    {
                        giris.SaldiriGirisiniKullan();

                        sesYonetim.Oynat("vurma");

                        hedef.TakeDamage(hasar);
                        anim.SetBool("vur", true);

                        vurabilirMi = false;
                    }

                }
                else
                {
                    hedef.CerceveKapa();
                }
            }

        }

    }

    public void Kullan()
    {
        kullan = !kullan;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, yakinMesKarakterin-0.5f);
    }

    public void VurAnim()
    {
        anim.SetBool("vur", false);
        vurabilirMi = true; 
    }

    void SifirlaKullan()
    {
        kullan = false;
    }

}

