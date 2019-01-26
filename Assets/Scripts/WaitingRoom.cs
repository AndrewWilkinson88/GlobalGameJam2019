using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaitingRoom : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public List<TileInstanceInfo> seats = new List<TileInstanceInfo>();

    private int occupiedSeats = 0;

    public bool IsSeatAvailable()
    {
        return (occupiedSeats < GetSeats().Count);
    }

    public List<TileInstanceInfo> GetSeats()
    {
        return ShelterManager.instance.objectMap[LocatableTile.TileTypes.WAITING_ROOM_BENCH];
    }

    public TileInstanceInfo TakeSeat()
    {
        if (!IsSeatAvailable())
            return null;

        foreach(TileInstanceInfo s in GetSeats())
        {
            if (!s.occupied)
            {
                s.occupied = true;
                occupiedSeats++;
                return s;
            }
        }

        return null;
    }

    public void LeaveSeat(TileInstanceInfo s)
    {
        if(s.occupied)
        {
            s.occupied = false;
            occupiedSeats--;
        }
    }
}
