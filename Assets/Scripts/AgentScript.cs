using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform targetTransform;
    [SerializeField] Transform[] baseTransform;
    [SerializeField] float ArrivingDistance;
    public bool ChasemodeOn = false;
    int BaseIndex;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ChasemodeOn)
        {
            agent.destination = targetTransform.position;
        }
        else
        {
            if (agent.remainingDistance < ArrivingDistance && !agent.pathPending)
            {
                BaseIndex++;
                if (BaseIndex >= baseTransform.Length)
                {
                    BaseIndex = 0;
                }
                agent.destination = baseTransform[BaseIndex].position;
            }
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChasemodeOn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChasemodeOn = false;
        }
    }
}
