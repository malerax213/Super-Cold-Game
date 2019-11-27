using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyIA : MonoBehaviour
{

    Transform player;
    UnityEngine.AI.NavMeshAgent nav;

    void Awake()
    {
        // references
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        nav.SetDestination(player.position);
        transform.LookAt(player);
    }
}