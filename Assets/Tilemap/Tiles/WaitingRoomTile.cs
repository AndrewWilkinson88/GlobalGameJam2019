using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.Tilemaps
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Waiting Room Tile", menuName = "Tiles/Waiting Room")]
    public class WaitingRoomTile : Tile
    {
        public bool StartUp(Vector3Int position, Tilemaps.ITilemap tilemap, GameObject go)
        {
            if (EditorApplication.isPlaying)
            { 
                Debug.Log("x: " + position.x + "  y: " + position.y);
                ShelterManager.instance.waitingRoom.seats.Add(new Seat(tilemap, position.x, position.y, false));
            }
            return true;
        }
    }
}
