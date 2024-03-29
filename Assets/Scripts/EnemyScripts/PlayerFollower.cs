using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Pathfinder))]

public class PlayerFollower : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private Pathfinder pathfinder;
    private List<Vector3> currentPath;
    [SerializeField] private float pathSearchDelay = 1f;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        pathfinder = GetComponent<Pathfinder>();
        pathfinder.target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }
    private void Update()
    {
        if (pathfinder.target == null)
            pathfinder.target = GameObject.FindGameObjectWithTag("Player").transform;
        if(currentPath != null && currentPath.Count > 0)
        {
            enemyMovement.currentDestination = currentPath[0];
            if(enemyMovement.ReachedDestination())
            {
                currentPath.RemoveAt(0);
            }
        }
    }

    private IEnumerator UpdatePath()
    {
        while(true)
        {
            currentPath = pathfinder.GetPath();
            yield return new WaitForSeconds(pathSearchDelay);
        }
    }
}
