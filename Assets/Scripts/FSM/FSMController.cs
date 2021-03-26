using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FSMController : MonoBehaviour
{
    [SerializeField] private float patrolRadius = 4f;
    public float speed = 5f;

    public List<Vector3> patrolPoints;
    public float patrolPauseTimer;
    public float patrolPauseTime;
    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Awake()
    {
        spawnPoint = transform.position;
        patrolPoints = CalculatePatrolPoints(spawnPoint, patrolRadius);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<Vector3> CalculatePatrolPoints(Vector3 origin, float radius)
    {
        List<Vector3> patrolPoints = new List<Vector3>
        {
            new Vector3(origin.x, origin.y),
            new Vector3(origin.x + radius, origin.y + radius),
            new Vector3(origin.x + radius, origin.y - radius),
            new Vector3(origin.x - radius, origin.y - radius),
            new Vector3(origin.x - radius, origin.y + radius)
        };

        return patrolPoints;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(spawnPoint, new Vector3(patrolRadius * 2, patrolRadius * 2));
    }
}
