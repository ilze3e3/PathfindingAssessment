using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{

    public List<Waypoint> waypoints;
    public Waypoint currWayPoint;
    public bool reachStatus;

    // Start is called at the start of the frame
    private void Start()
    {
        ChooseWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(reachStatus)
        {
            ChooseWaypoint();
            reachStatus = false;
        }


        if (!this.GetComponent<NavMeshAgent>().pathPending && this.GetComponent<NavMeshAgent>().remainingDistance < 0.1f)
        {
            reachStatus = true;
        }

        this.GetComponent<NavMeshAgent>().destination = currWayPoint.transform.position;
    }

    private void ChooseWaypoint()
    {
        if(waypoints != null && waypoints.Count != 0)
        {
            currWayPoint = waypoints[(int)Random.Range(0, waypoints.Count)];
        }
    }
}
