using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterManager : MonoBehaviour
{
    public static ShelterManager instance;

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
