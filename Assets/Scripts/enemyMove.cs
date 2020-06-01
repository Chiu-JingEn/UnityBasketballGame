using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Person");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
