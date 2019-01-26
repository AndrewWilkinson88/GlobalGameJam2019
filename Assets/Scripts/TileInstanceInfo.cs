using UnityEngine.Tilemaps;
using UnityEngine;
using System;

public class TileInstanceInfo
{
    public LocatableTile.TileTypes type;
    public ITilemap tilemap;
    public int x;
    public int y;
    public bool occupied;

    public TileInstanceInfo(LocatableTile.TileTypes type,  ITilemap tilemap, int x, int y, bool occupied)
    {
        this.type = type;
        this.tilemap = tilemap;
        this.x = x;
        this.y = y;
        this.occupied = occupied;
    }
}