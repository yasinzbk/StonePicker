using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaynak : MonoBehaviour
{
    public float startingHealth = 100; // Baþlangýç saðlýðý
    public float currentHealth; // Mevcut saðlýk
    public bool isDead = false; // Ölü mü?

    public GameObject cerceve;

    public GameObject tasCevher;
    public float dagilma;
    void Start()
    {
        currentHealth = startingHealth; // Baþlangýçta mevcut saðlýk, baþlangýç saðlýðýna eþit olacak
    }

    // Hasar almak için çaðrýlacak fonksiyon
    public void TakeDamage(float damageAmount)
    {
        // Eðer öldüyse, fonksiyondan çýk
        if (isDead)
        {
            return;
        }

        // Hasar alýnýr, mevcut saðlýktan düþülür
        currentHealth -= damageAmount;

        // Eðer saðlýk sýfýra veya daha azýna düþtüyse, ölü olduðunu belirtecek
        if (currentHealth <= 0)
        {
            isDead = true;
            // Ölümle ilgili ek iþlemler yapabilirsiniz
            // Örneðin, ölüm animasyonunu oynatmak
            // veya nesneyi yok etmek
            GameObject kaynak = Instantiate(tasCevher);
            kaynak.transform.position = new Vector2(transform.position.x + dagilma, transform.position.y + dagilma);

            GameObject kaynak2 = Instantiate(tasCevher);
            kaynak2.transform.position = new Vector2(transform.position.x + dagilma, transform.position.y - dagilma);


            Destroy(gameObject);
        }
    }


    private void OnMouseExit()
    {
        CerceveKapa();

    }

    public void CerceveAc()
    {
        cerceve.SetActive(true);
    }
    public void CerceveKapa()
    {
        cerceve.SetActive(false);
    }

        
}