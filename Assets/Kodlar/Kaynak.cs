using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaynak : MonoBehaviour
{
    public float startingHealth = 100; // Ba�lang�� sa�l���
    public float currentHealth; // Mevcut sa�l�k
    public bool isDead = false; // �l� m�?

    public GameObject cerceve;

    public GameObject tasCevher;
    public float dagilma;
    void Start()
    {
        currentHealth = startingHealth; // Ba�lang��ta mevcut sa�l�k, ba�lang�� sa�l���na e�it olacak
    }

    // Hasar almak i�in �a�r�lacak fonksiyon
    public void TakeDamage(float damageAmount)
    {
        // E�er �ld�yse, fonksiyondan ��k
        if (isDead)
        {
            return;
        }

        // Hasar al�n�r, mevcut sa�l�ktan d���l�r
        currentHealth -= damageAmount;

        // E�er sa�l�k s�f�ra veya daha az�na d��t�yse, �l� oldu�unu belirtecek
        if (currentHealth <= 0)
        {
            isDead = true;
            // �l�mle ilgili ek i�lemler yapabilirsiniz
            // �rne�in, �l�m animasyonunu oynatmak
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