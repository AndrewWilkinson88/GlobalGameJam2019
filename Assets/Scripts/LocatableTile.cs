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
    [CreateAssetMenu(fileName = "New Locateable Tile", menuName = "Tiles/Locateable Tile")]
    public class LocatableTile : Tile
    {
        [Serializable]
        public enum TileTypes
        {
            WAITING_ROOM_ENTRANCE,
            WAITING_ROOM_BENCH,
            CAFETERIA_ENTRANCE,
            CAFETERIA_SEAT,
            DORMATORY_ENTRANCE,
            DORMATORY_BED
        }

        public TileTypes tileType;


        public bool StartUp(Vector3Int position, Tilemaps.ITilemap tilemap, GameObject go)
        {
            if (EditorApplication.isPlaying)
            { 
                if (!ShelterManager.instance.objectMap.ContainsKey(tileType))
                {
                    ShelterManager.instance.objectMap.Add(tileType, new List<TileInstanceInfo>());
                }

                ShelterManager.instance.objectMap[tileType].Add( new TileInstanceInfo(tileType, tilemap, position.x, position.y, false) );
            }
            return true;
        }
    }
}
