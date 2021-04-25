using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallGenerator : TileGenerator
{
    protected override void GenerateTiles()
    {
        for (int i = 0; i < wallThickness; i++)
        {
            Tile tile = null;
            float diceRoll = Random.Range(0f, 1f);
            if (diceRoll <= probabilityOfSpawn)
            {
                int rand = Random.Range(0, tiles.Length - 1);
                tile = tiles[rand];
            }

            addTile(zero_x + i, zero_y, tile);
            addTile(zero_x + width - i -1, zero_y, tile);
        }
    }
}
