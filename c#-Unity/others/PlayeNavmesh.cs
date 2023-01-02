using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Move GameObject with NavMesh
public class PlayeNavmesh : MonoBehaviour
{
    public Transform movePositiontransform;
    public NavMeshAgent navMeshAgentYes;
    public void Awake()
    {
        navMeshAgentYes = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        navMeshAgentYes.destination = movePositiontransform.position;
  
    }
}
