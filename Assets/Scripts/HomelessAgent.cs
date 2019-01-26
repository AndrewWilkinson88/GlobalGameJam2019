using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Pathfinding;
using UnityEngine.Tilemaps;

public class HomelessAgent : MonoBehaviour
{
    public Tilemap collisionMap;

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

    private bool forceStopCol = false;
    private bool hasTarget = false;
    private Vector3 targetPos;
    private Sequence moveSequence;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitAFrame());
    }

    IEnumerator waitAFrame()
    {
        yield return new WaitForEndOfFrame();

        hasTarget = true;
        Seat targetSeat = ShelterManager.instance.waitingRoom.doors[0];
        targetPos = new Vector3(targetSeat.x, targetSeat.y);
    }

    // Update is called once per frame
    void Update()
    {
        if( !(DOTween.IsTweening(moveSequence)) && hasTarget)
        {
            moveSequence = DOTween.Sequence();
            hasTarget = false;

            Vector3 currentPosition = ShelterManager.instance.grid.WorldToCell(transform.position);
            currentPosition[2] = 0.0f;
            List<Vector3> path = AStar.FindPath(collisionMap, currentPosition, targetPos);
            Vector3 previous = currentPosition;

            foreach ( Vector3 v in path)
            {
                Vector3 mappedPos = ShelterManager.instance.grid.CellToWorld(new Vector3Int((int)v.x, (int)v.y, 0));
                moveSequence.Append(transform.DOMove(mappedPos, 0.2f).SetEase(Ease.Linear));
                previous = v;
            }
            if( curLocation != null )
            {
                moveSequence.Append(transform.DOMove(ShelterManager.instance.grid.CellToWorld(new Vector3Int(curLocation.x, curLocation.y, 0)), 0.2f).SetEase(Ease.Linear));
            }
            moveSequence.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!forceStopCol)
        {
            if (col.GetComponent<EntranceHandler>())
            {
                if (InNeed() || ShelterManager.instance.waitingRoom.IsSeatAvailable())
                {
                    curLocation = ShelterManager.instance.waitingRoom.TakeSeat();
                    if (curLocation != null)
                    {
                        targetPos = new Vector3(curLocation.x,curLocation.y);
                        hasTarget = true;
                    }
                    forceStopCol = true;
                }
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
