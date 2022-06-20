using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private Vector3 position;
    private PathNode parent;
    private Vector3 target;
    private float desiredDistanceToTarget;
    private float g;
    private float h;

    public Vector3 Position
    {
        get { return position; }
    }
    public PathNode Parent
    {
        get { return parent; }
    }
    public float G
    {
        get { return g; }
    }
    public float H
    {
        get { return h; }
    }
    public float F
    {
        get { return g + h; }
    }

    public PathNode(Vector3 position, PathNode parent, Vector3 target, float desiredDistanceToTarget)
    {
        this.position = position;
        this.parent = parent;
        this.target = target;
        this.desiredDistanceToTarget = desiredDistanceToTarget;
        InitG();
        InitH();
    }

    private void InitG()
    {
        if (parent == null)
            g = 0f;
        else
            g = parent.G + Vector3.Distance(parent.Position, position);
    }
    private void InitH()
    {
        if (parent == null)
            h = 0f;
        else
            h = Vector3.Distance(position, target);
    }
}
