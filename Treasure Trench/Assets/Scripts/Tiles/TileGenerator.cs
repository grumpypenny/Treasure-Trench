using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    [Header ("Game Objects")]
    public Tilemap tm;
    public Tile[] tiles;

    [Header ("Bottome Left Tile Coordinates")]
    public int zero_x = -11;
    public int zero_y = -5;

    [Header ("Grid dimensions")]
    public int width = 22;
    public int height = 10;

    [Header ("Spawn Parameters")]
    public float tileUpdateInterval = 1f;
    public float probabilityOfSpawn = 1f;

    [Header("Spawn Dimensions")]
    public int wallThickness = 3;
    // Start is called before the first frame update
    protected void Start()
    {
        probabilityOfSpawn = Mathf.Clamp(probabilityOfSpawn, 0f, 1f);
        GenerateTiles();
        InvokeRepeating("TileUpdate", tileUpdateInterval, tileUpdateInterval);
    }

    protected virtual void addTile(int x, int y, Tile tile)
    {
        tm.SetTile(new Vector3Int(x, y, 0), tile);
    }

    protected virtual void GenerateTiles()
    {
        // addTile(-11, -5, tiles[0]);
        
        for (int i = 0; i < width; i++)
        {
            Tile tile = null;
            float diceRoll = Random.Range(0f, 1f);
            if (diceRoll <= probabilityOfSpawn)
            {
                int rand = Random.Range(0, tiles.Length - 1);
                tile = tiles[rand];
            }
            
            addTile(zero_x + i, zero_y, tile);
        }
    }

    protected void MoveTilesUp()
    {
        for (int j = height; j > 0; j--)
        {
            for (int i = 0; i < width; i++)
            {
                TileBase tile = tm.GetTile(new Vector3Int(zero_x + i, zero_y + j - 1, 0));
                tm.SetTile(new Vector3Int(zero_x + i, zero_y + j, 0), tile);
            }
        }
    }

    protected void TileUpdate()
    {
        MoveTilesUp();
        GenerateTiles();
    }
}
