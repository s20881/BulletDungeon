using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float desiredDistanceToPlayer = 1f;
    [SerializeField] private float step = 1f;
    private CircleCollider2D cc;
    private EnemyMovement enemy;
    private Transform player;

    [SerializeField] private GameObject markerPrefab;

    private void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        enemy = GetComponent<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (desiredDistanceToPlayer < step * 0.71) // 0.71 > sqrt(2) / 2
            Debug.LogWarning("Desired distance to player is too small. It can be impossible to find a path.");
    }
    private void Update()
    {
        if (enemy.ReachedDestination() && Vector3.Distance(player.position, transform.position) > desiredDistanceToPlayer)
        {
            if (PlayerInSight())
            {
                Debug.Log("Player in sight");
                enemy.currentDestination = Vector2.MoveTowards(transform.position, player.position, step);
            }
            else
            {
                Debug.Log("Searching for path");
                enemy.currentDestination = GetPath()[1];
            }
        }
        else
        {
            Debug.Log("Moving or player close enough");
        }
    }

    private List<Vector3> GetNeighbors(Vector3 pos)
    {
        List<Vector3> neighbors = new List<Vector3>();
        neighbors.Add(pos + Vector3.left * step);
        neighbors.Add(pos + Vector3.right * step);
        neighbors.Add(pos + Vector3.up * step);
        neighbors.Add(pos + Vector3.down * step);
        neighbors.Add(pos + Vector3.left * step + Vector3.up * step);
        neighbors.Add(pos + Vector3.right * step + Vector3.up * step);
        neighbors.Add(pos + Vector3.left * step + Vector3.down * step);
        neighbors.Add(pos + Vector3.right * step + Vector3.down * step);
        return neighbors;
    }
    private List<Vector3> GetAccessibleNeighbors(List<Vector3> neighbors, Vector3 pos)
    {
        List<Vector3> result = new List<Vector3>();
        foreach(Vector3 neighbor in neighbors)
        {
            int mask = LayerMask.GetMask("Obstacle");
            RaycastHit2D hit = Physics2D.CircleCast(pos, cc.radius, neighbor - pos, Vector3.Distance(neighbor, pos), mask);
            if (hit.collider == null)
                result.Add(neighbor);
        }
        return result;
    }
    private List<Vector3> GetPath()
    {
        PathNode target = null;
        List<PathNode> a = new List<PathNode>();
        List<PathNode> b = new List<PathNode>();
        a.Add(new PathNode(transform.position, null, player.position, desiredDistanceToPlayer));
        while(a.Count > 0 && target == null)
        {
            PathNode q = BestNode(a);
            a.Remove(q);
            List<PathNode> children = new List<PathNode>();
            foreach(Vector3 neighbor in GetAccessibleNeighbors(GetNeighbors(q.Position), q.Position))
            {
                children.Add(new PathNode(neighbor, q, player.position, desiredDistanceToPlayer));
            }
            foreach(PathNode child in children)
            {
                if(Vector3.Distance(child.Position, player.position) <= desiredDistanceToPlayer)
                {
                    target = child;
                    break;
                }
                else if(ExistsBetter(a, child) || ExistsBetter(b, child))
                {
                    continue;
                }
                else
                {
                    a.Add(child);
                }
            }
            b.Add(q);
        }
        if (target == null)
        {
            Debug.Log("Pathfinding finished without finding the target.");
            return null;
        }
        else
        {
            List<Vector3> path = new List<Vector3>();
            PathNode current = target;
            do
            {
                path.Add(current.Position);
                current = current.Parent;
            }
            while (current != null);
            path.Reverse();
            return path;
        }
    }
    private PathNode BestNode(List<PathNode> nodes)
    {
        PathNode best = nodes[0];
        for(int i = 1; i < nodes.Count; i++)
        {
            if (nodes[i].F < best.F)
                best = nodes[i];
        }
        return best;
    }
    private bool ExistsBetter(List<PathNode> list, PathNode node)
    {
        foreach(PathNode element in list)
        {
            if (element.Position == node.Position && element.F < node.F)
                return true;
        }
        return false;
    }
    private bool PlayerInSight()
    {
        int mask = LayerMask.GetMask("Obstacle");
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, cc.radius, player.position - transform.position, Vector3.Distance(player.position, transform.position), mask);
        if (hit.collider == null)
            return true;
        else
            return false;
    }

    // debug
    [ContextMenu("Test path")] private void TestPath()
    {
        List<Vector3> path = GetPath();
        foreach (Vector3 pos in path)
        {
            Instantiate<GameObject>(markerPrefab, pos, Quaternion.identity);
        }
    }
    [ContextMenu("Accessible neighbors")] private void TestAccessibleNeighbors()
    {
        List<Vector3> neighbors = GetAccessibleNeighbors(GetNeighbors(transform.position), transform.position);
        foreach (Vector3 pos in neighbors)
        {
            Instantiate<GameObject>(markerPrefab, pos, Quaternion.identity);
        }
    }
}
