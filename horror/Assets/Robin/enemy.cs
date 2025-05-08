using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyAI : MonoBehaviour
{
    public float maxDistance = Mathf.Infinity; // Maximum distance for chasing players

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        GameObject closestPlayer = FindClosestPlayer();

        if (closestPlayer != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, closestPlayer.transform.position);

            if (distanceToPlayer <= maxDistance)
            {
                agent.SetDestination(closestPlayer.transform.position);
            }
        }
    }

    GameObject FindClosestPlayer()
    {
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject player in GetAllPlayers())
        {
            if (player != null)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < closestDistance)
                {
                    closest = player;
                    closestDistance = distance;
                }
            }
        }

        return closest;
    }

    GameObject[] GetAllPlayers()
    {
        return GameObject.FindGameObjectsWithTag("Player");
    }
}
