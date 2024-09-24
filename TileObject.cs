using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using System;

//Reference to tile object in game hierarchy
public class TileObject : MonoBehaviour
{
    private TileType tileType;

    public MeshRenderer MeshRenderer;
    public MeshFilter MeshFilter;

    [SerializedDictionary("Tile type","Tile data")]
    public SerializedDictionary<TileType, TileData> tileTypeDatas;

    public void SetTileType(TileType newTileType)
    {
        //Set new tile type and render it
        tileType = newTileType;

        if(MeshRenderer && MeshFilter)
        {
            TileData tileData = tileTypeDatas[newTileType];
            MeshFilter.mesh = tileData.mesh;
            MeshRenderer.material = tileData.material;
        }
    }
}

[Serializable]
public struct TileData
{
    public Mesh mesh;
    public Material material;
}

//All types of tiles for now just grass and stone
public enum TileType
{
    Grass, Stone
}