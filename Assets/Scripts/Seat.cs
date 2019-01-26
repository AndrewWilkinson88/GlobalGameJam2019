using UnityEngine.Tilemaps;
using UnityEngine;
using System;

public class Seat
{
    public ITilemap tilemap;
    public int x;
    public int y;
    public bool occupied;

    public Seat( ITilemap t, int x, int y, bool occupied)
    {
        this.tilemap = t;
        this.x = x;
        this.y = y;
        this.occupied = occupied;
    }
}