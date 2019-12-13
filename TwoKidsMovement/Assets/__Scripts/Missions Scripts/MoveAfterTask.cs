using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAfterTask : MonoBehaviour
{

    GameObject npc;
    [SerializeField]
    public Transform[] waypoints;
    [SerializeField]
    float acurecy;
  // float turnspeed;
  // float speed;
    int currentwaypoint;
    public string waypointtag;
    NavMeshAgent agent;
    [SerializeField]
    TaskItem activate_this_event;
    [SerializeField]
    TaskItem finish_this_event;

    NpcState npcState = NpcState.beforeMission;

    void Start()
    {
        activate_this_event.thisTaskFinished += switchstate;
        finish_this_event.thisTaskFinished += switchstate;
        agent = GetComponent<NavMeshAgent>();
        npc = this.gameObject;
        currentwaypoint = 0;

    }

    public void switchstate()
    {
        if (npcState == NpcState.beforeMission)
            npcState = NpcState.whileMission;
        if (npcState == NpcState.whileMission)
            npcState = NpcState.afterMission;
    }

    // Update is called once per frame
    void Update()
    {
        switch(npcState)            
        {
            case NpcState.beforeMission:

            // write here before



            break;

            case NpcState.whileMission:

                try
                {
                    if (waypoints.Length == 0) return;
                    if (Vector3.Distance(waypoints[currentwaypoint].transform.position, npc.transform.position) < 1)
                    {
                        currentwaypoint++;
                        if (currentwaypoint >= waypoints.Length)
                        {
                            //got to the end of the route
                        }
                    }
                    agent.SetDestination(waypoints[currentwaypoint].transform.position);

                }
                catch
                { }
                break;
            case NpcState.afterMission:
                try
                {
                    if (waypoints.Length == 0) return;
                    if (Vector3.Distance(waypoints[currentwaypoint].transform.position, npc.transform.position) < 1)
                    {
                        currentwaypoint--;
                        if (currentwaypoint == 0)
                        {
                            //got to the end of the route
                        }
                    }
                    agent.SetDestination(waypoints[currentwaypoint].transform.position);

                }
                catch { }
                break;


        }


        
      //  var diraction = waypoints[currentwaypoint].transform.position - npc.transform.position;
      //  npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(diraction), turnspeed * Time.deltaTime);
      //  npc.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}

public enum NpcState
{
    beforeMission, whileMission, afterMission
}
