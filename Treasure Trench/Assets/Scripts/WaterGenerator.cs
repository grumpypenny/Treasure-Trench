using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterGenerator : TileGenerator
{
    protected override void GenerateTiles()
    {
        for (int i = wallThickness; i < width - wallThickness; i++)
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
}
