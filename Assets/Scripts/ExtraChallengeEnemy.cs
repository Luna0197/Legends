using UnityEngine;

public class ExtraChallengeEnemy : MonoBehaviour
{
    public Stats enemyStats;
    public Transform[] patrolPoints;
    public string playerTag = "Player";
    public float avoidRadius = 5f;
    public float avoidSpeed = 5f;
    public float fixedYPosition;

    private HealthManager healthManager; 

    [System.Serializable]
    public struct Stats
    {
        [Header("Enemy Settings")]
        public float speed;
        public bool move;
    }

    void Awake()
    {
        healthManager = FindObjectOfType<HealthManager>(); 
    }

    void Update()
    {
        if (healthManager != null && healthManager.health == 100)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

            if (players.Length > 0)
            {
                Vector3 directionToPlayer = players[0].transform.position - transform.position;

                if (directionToPlayer.magnitude < avoidRadius)
                {
                    directionToPlayer.Normalize();
                    Vector3 targetPosition = transform.position - directionToPlayer;
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, avoidSpeed * Time.deltaTime);
                    Vector3 newPosition = transform.position;
                    newPosition.y = fixedYPosition;
                    transform.position = newPosition;
                }
            }
        }
        
    }

    
}
