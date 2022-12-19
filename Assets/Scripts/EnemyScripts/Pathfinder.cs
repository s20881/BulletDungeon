using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float desiredDistanceToTarget = 1f;
    [SerializeField] private float step = 1f;
    [SerializeField] private int maxIterations = 1000;
    private CircleCollider2D cc;

    private void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        if (desiredDistanceToTarget < step * 0.71) // 0.71 > sqrt(2) / 2
        {
            Debug.LogWarning("Desired distance to target is too small. It can be impossible to find a path because of the step.");
            desiredDistanceToTarget = step;
        }
        if(desiredDistanceToTarget < cc.radius * 2 * 1.42) // desired distance should be at least sqrt(2) * 2 * collider_radius
        {
            Debug.LogWarning("Desired distance to target is too small. It can be impossible to find a path bezcause of the collider.");
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
    private List<Vector3> GetAccessibleNeighbors(Vector3 pos)
    {
        List<Vector3> neighbors = GetNeighbors(pos);
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
    public List<Vector3> GetPath()
    {
        PathNode targetNode = null;
        List<PathNode> a = new List<PathNode>();
        List<PathNode> b = new List<PathNode>();
        PathNode start = new PathNode(transform.position, null, target.position);
        a.Add(start);
        if(IsSatisfactory(start))
            targetNode = start;
        int i = 0;
        while (a.Count > 0 && targetNode == null && i < maxIterations)
        {
            i++;
            PathNode q = BestNode(a);
            a.Remove(q);
            List<PathNode> children = new List<PathNode>();
            foreach(Vector3 neighbor in GetAccessibleNeighbors(q.Position))
            {
                children.Add(new PathNode(neighbor, q, target.position));
            }
            foreach(PathNode child in children)
            {
                if(IsSatisfactory(child))
                {
                    targetNode = child;
                }
                else if(!ExistsBetter(a, child) && !ExistsBetter(b, child))
                {
                    a.Add(child);
                }
            }
            b.Add(q);
        }
        if (targetNode == null)
        {
            if (a.Count > 0)
                return BestNode(a).Backtrack;
            else
                return null;
        }
        else
        {
            return targetNode.Backtrack;
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
            if (element.Position == node.Position && element.F <= node.F)
                return true;
        }
        return false;
    }
    private bool IsSatisfactory(PathNode node)
    {
        return Vector3.Distance(node.Position, target.position) < desiredDistanceToTarget;
    }
}
