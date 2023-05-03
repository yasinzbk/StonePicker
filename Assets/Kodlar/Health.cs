using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth = 100; // Baþlangýç saðlýðý
    public float currentHealth; // Mevcut saðlýk
    public bool isDead = false; // Ölü mü?

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
            Destroy(gameObject);
        }
    }
}