using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;

    public Camera mainCamera;
    public LayerMask resourceMask;
    public Karakter karakter;
    public Vector2 characterPosition { get; private set; }

    private GirisKarakter giris;
    private bool kullan; // kalkabilir amele yontemi

    public float yakinMesKarakterin = 5f;

    Animator anim;

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
        if (giris.saldiri && kullan)  // yeni input sistemde fareye erisime bak
        {
            giris.SaldiriGirisiniKullan();
            Debug.Log("yarraaaaaaaaa");
            characterPosition = transform.position;

            Vector2 mouseWorldPosition = giris.fareKonumu;
            //giris.saldiri = false;

            Collider2D[] hits = Physics2D.OverlapPointAll(mouseWorldPosition, resourceMask);



            foreach (Collider2D hit in hits)
            {
                Health can = hit.gameObject.GetComponent<Health>();


                if (can != null)
                {
                    float distanceToResource = Vector2.Distance(characterPosition, can.transform.position);
                    //Debug.Log(distanceToResource);

                    if (distanceToResource < yakinMesKarakterin)
                    {
                        can.TakeDamage(damage);
                        anim.SetBool("vur", true);
                    }
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
        Gizmos.DrawWireSphere(transform.position, yakinMesKarakterin);
    }

    public void VurAnim()
    {
        anim.SetBool("vur", false);
    }

    void SifirlaKullan()
    {
        kullan = false;
    }
}

