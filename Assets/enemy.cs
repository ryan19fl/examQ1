using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public enum enemystate
    {
        idel,patrol,chase
    }
    public enemystate enemystates;
    public Transform[] waypoint;
    public int lastwaypointindex;
    public Transform targetwaypoint;
    public int targetwaypointindex = 0;
    public float mindistance = 0.4f;
    public float movespeed = 5f;
    public float rotationspeed = 5f;
    NavMeshAgent agent;
    public GameObject player;
    public bool playerinrange;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        lastwaypointindex = waypoint.Length - 1;
        targetwaypoint = waypoint[targetwaypointindex];
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(enemystates)
        {
            case enemystate.idel:
                Debug.Log("in idle");
           
                break;
            case enemystate.patrol:
                patroling();
                //source.Play();
                Debug.Log("in patrol");
                
                break;
            case enemystate.chase:
                default:
                agent.destination = player.transform.position;
                Debug.Log("in chase");
                break;

        }
            
    }
    public void patroling()
    {
        Vector3 diractiontowaypoint = targetwaypoint.position - transform.position;
        Quaternion rotationtowaypoint = Quaternion.LookRotation(diractiontowaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationtowaypoint, rotationspeed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetwaypoint.position);
        Debug.Log(distance);
        if (distance <= mindistance)
        {
            targetwaypointindex++;
            if (targetwaypointindex > lastwaypointindex)
            {
                targetwaypointindex = 0;

            }

            targetwaypoint = waypoint[targetwaypointindex];
        }
       
        transform.position = Vector3.MoveTowards(transform.position, targetwaypoint.position, movespeed * Time.deltaTime);
    }
}

