using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public int xLength, zLength;
    public GameObject TilePrefab;

    private int posXY, posZY;

    private void Update()
    {
        //If user presses J generate the map
        if(Input.GetKeyDown(KeyCode.J))
        {
            Generate();
        }
    }

    public void Generate()
    {
        posXY = posZY = 0;

        for(int i = -xLength / 2; i <= xLength / 2; i += 1)
        {
            System.Random rng;
            for (int j = -zLength / 2; j <= zLength / 2; j += 1)
            {
                //Generate row
                GenerateRow(i,j);

                rng = new System.Random();
                posZY += rng.Next(-1, 1);
            }

            rng = new System.Random();
            posXY += rng.Next(-1, 1);
            posZY = posXY;
        }
    }

    public void GenerateRow(int x, int z)
    {
        //-30 is minimum Y position
        int posY = posZY;

        for (int y = -30; y <= posY; y++)
        {
            TileType type = TileType.Grass;
            if(posY - y >= 3)
            {
                type = TileType.Stone;
            }

            GenerateTile(type, new Vector3Int(x, y, z));
        }
    }

    public void GenerateTile(TileType type, Vector3Int pos)
    {
        GameObject tile = Instantiate(TilePrefab, pos, Quaternion.identity);
        TileObject tileObject = tile.GetComponent<TileObject>();

        tileObject.SetTileType(type);
    }
}

