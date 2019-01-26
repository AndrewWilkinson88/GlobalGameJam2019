using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomelessAgent : MonoBehaviour
{
    //Percentage of different traits
    public float food;
    public float energy;
    public float health;

    public float anger;
    public float patience;

    public float foodNeedsLimit = .3f;
    public float energyNeedLimit = .3f;
    public float healthNeedsLimit = .3f;

    public float speed = .2f;

    public enum Actions
    {
        Walking,
        TakingSeat,
    }

    public Seat curLocation;
    public Vector3 moveGoal;

    // Start is called before the first frame update
    void Start()
    {
        moveGoal = this.transform.position + new Vector3(40f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.position + (moveGoal - this.transform.position).normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if(col.GetComponent<EntranceHandler>())
        {
            if( InNeed() || ShelterManager.instance.waitingRoom.IsSeatAvailable() )
            {
                curLocation = ShelterManager.instance.waitingRoom.TakeSeat();
                moveGoal = new Vector3(curLocation.x, curLocation.y);
            }
        }
    }

    public bool InNeed()
    {
        return (NeedsFood() || NeedsEnergy() || NeedsHealth());
    }

    public bool NeedsFood()
    {
        return food < foodNeedsLimit;
    }

    public bool NeedsEnergy()
    {
        return energy < energyNeedLimit;
    }

    public bool NeedsHealth()
    {
        return health < healthNeedsLimit;
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }
}
