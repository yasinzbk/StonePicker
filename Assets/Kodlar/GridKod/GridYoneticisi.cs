using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
[RequireComponent(typeof(GridMap))]
public class GridYoneticisi : MonoBehaviour
{
    Tilemap tilemap;
    GridMap grid;

    [SerializeField] TileSet tileSet;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
        grid = GetComponent<GridMap>();
        grid.Olustur(12, 12);
        Set(1, 1, 2);
        Set(2, 1, 2);
        Set(1, 2, 2);
        TileMapiGuncelle();
    }

    public void TileMapiGuncelle()
    {
        for (int i = 0; i < grid.uzunluk; i++)
        {
            for (int j = 0; j < grid.yukseklik; j++)
            {
                KareyiGuncelle(i, j);
            }
        }
    }

    private void KareyiGuncelle(int i, int j)
    {
        int tileID = grid.Get(i, j);
        if (tileID == -1)
        {
            return;
        }

        tilemap.SetTile(new Vector3Int(i, j, 0), tileSet.tiles[tileID]);
    }

    public void Set(int x, int y, int to)
    {
        grid.Set(x, y, to);
        KareyiGuncelle(x, y);
    }

    public void Ekle(int i, int j, int tileID)
    {
        tilemap.SetTile(new Vector3Int(i, j, 0), tileSet.tiles[tileID]);
    }

}
