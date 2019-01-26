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
    [CreateAssetMenu(fileName = "New Waiting Room Tile", menuName = "Tiles/DoorTile")]
    public class DoorTile : Tile
    {
        public bool StartUp(Vector3Int position, Tilemaps.ITilemap tilemap, GameObject go)
        {
            if (EditorApplication.isPlaying)
            {
                ShelterManager.instance.waitingRoom.doors.Add(new Seat(tilemap, position.x, position.y, false));
            }
            return true;
        }
    }
}
