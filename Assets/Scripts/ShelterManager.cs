using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShelterManager : MonoBehaviour
{
    public static ShelterManager instance;

    public Dictionary<LocatableTile.TileTypes, List<TileInstanceInfo> > objectMap = new Dictionary<LocatableTile.TileTypes, List<TileInstanceInfo>>();

    public Grid grid;
    public WaitingRoom waitingRoom;
    public Cafeteria cafeteria;
    public Dormatory dormatory;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
