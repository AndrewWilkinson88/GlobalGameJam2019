using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterManager : MonoBehaviour
{
    public static ShelterManager instance;

    public WaitingRoom waitingRoom;
    public Cafeteria cafeteria;
    public Dormatory dormatory;

    public Grid grid;

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
