using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridKontrol : MonoBehaviour
{
    [SerializeField] Tilemap sablonTileMap;
    [SerializeField] GridYoneticisi gridYoneticisi;

    private void Update()
    {
       // ZeminEkle();
    }

    private void ZeminEkle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tiklananPozisyon = sablonTileMap.WorldToCell(worldPoint); // world pozisyonu en yakin hucreye ayarliyor olmasi lazim(yani en yakin int degerlerine)
            gridYoneticisi.Ekle(tiklananPozisyon.x, tiklananPozisyon.y, 0);
        }
    }
}
