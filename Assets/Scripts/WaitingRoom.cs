using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public List<Seat> seats;

    private int occupiedSeats = 0;

    public bool IsSeatAvailable()
    {
        return (occupiedSeats < seats.Count);
    }

    public Seat TakeSeat()
    {
        if (!IsSeatAvailable())
            return null;

        foreach(Seat s in seats)
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

    public void LeaveSeat(Seat s)
    {
        if(s.occupied)
        {
            s.occupied = false;
            occupiedSeats--;
        }
    }
}
