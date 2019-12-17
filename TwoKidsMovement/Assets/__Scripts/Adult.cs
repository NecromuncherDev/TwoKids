using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Adult : MonoBehaviour
{
    private GameObject spawnObject;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        spawnObject = new GameObject();
        spawnObject.transform.position = transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public Transform GetSpawnTransform()
    {
        return spawnObject.transform;
    }
}
