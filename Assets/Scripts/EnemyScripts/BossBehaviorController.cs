using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviorController : MonoBehaviour
{
    [SerializeField] private CircleCollider2D playerCloseRange;
    [SerializeField] private float reactionTime = 1f;
    private Transform player;
    private Animator animator;

    public bool PlayerVisible
    {
        get
        {
            int mask = LayerMask.GetMask("Obstacle");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, DistanceToPlayer, mask);
            return hit.collider == null;
        }
    }
    public bool PlayerFar
    {
        get { return DistanceToPlayer > playerCloseRange.radius; }
    }
    public float DistanceToPlayer
    {
        get
        {
            return Vector2.Distance(transform.position, player.position);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        StartCoroutine(UpdateAnimatorParameters());
    }
    private IEnumerator UpdateAnimatorParameters()
    {
        while(animator != null)
        {
            animator.SetBool("playerVisible", PlayerVisible);
            animator.SetBool("playerFar", PlayerFar);
            yield return new WaitForSeconds(reactionTime);
        }
    }
}
