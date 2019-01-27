using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomelessAgent : MonoBehaviour, IPointerClickHandler
{
    public GameObject choice;

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

    public enum State
    {
        WALKING_TO_BUILDING,
        WALKING_TO_WAIT,
        WAITING,
        WALKING_TO_EAT,
        EATING,
        WALKING_TO_SLEEP,
        SLEEPING
    }

    public State curState = State.WALKING_TO_BUILDING;

    public TileInstanceInfo curLocation;
    public Vector3 moveGoal;

    // Start is called before the first frame update
    void Start()
    {
        moveGoal = this.transform.position + new Vector3(40f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        switch(curState)
        {
            case State.WALKING_TO_BUILDING:
                if (WalkTowardGoal())
                {
                    
                }
                break;
            case State.WALKING_TO_EAT:
                if (WalkTowardGoal())
                {

                }
                break;
            case State.WALKING_TO_SLEEP:
                if (WalkTowardGoal())
                {

                }
                break;
            case State.WALKING_TO_WAIT:
                if (WalkTowardGoal())
                {
                    ChangeState(State.WAITING);
                }
                break;
        }
    }

    bool WalkTowardGoal()
    {
        if ((moveGoal - this.transform.position).magnitude > speed)
        {
            this.transform.position = this.transform.position + (moveGoal - this.transform.position).normalized * speed;
            return false;
        }
        else
        {
            this.transform.position = moveGoal;
            return true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if(col.GetComponent<EntranceHandler>())
        {
            if( InNeed() || ShelterManager.instance.waitingRoom.IsSeatAvailable() )
            {
                ChangeState(State.WALKING_TO_WAIT);
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

    public void ChangeState(State s)
    {
        //Debug.Log("CHANGING STATE : " + s.ToString());
        if(curState != s)
        {
            State lastState = curState;
            curState = s;
            switch(lastState)
            {
                case State.WAITING:
                    SetChoiceMenu(false);
                    break;
            }
            switch(curState)
            {
                case State.WALKING_TO_WAIT:
                    curLocation = ShelterManager.instance.waitingRoom.TakeSeat();

                    moveGoal = ShelterManager.instance.grid.CellToWorld(new Vector3Int(curLocation.x, curLocation.y, 0));
                    Debug.Log(moveGoal);
                    break;
            }
        }        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("GOT CLICK IN STATE: " + curState);
        switch(curState)
        {
            case State.WAITING:
                ToggleChoiceMenu();
                break;
        }
    }

    public void ToggleChoiceMenu()
    {
        SetChoiceMenu(!choice.activeSelf);
    }

    public void SetChoiceMenu(bool visible)
    {
        choice.SetActive(visible);
    }
}
