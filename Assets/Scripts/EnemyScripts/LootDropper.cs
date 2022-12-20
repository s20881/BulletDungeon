using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropper : StateMachineBehaviour
{
    [SerializeField] private GameObject gelPrefab;
    [SerializeField] private GameObject scrapPrefab;
    [SerializeField] private float gelDropChance = 0.3f;
    [SerializeField] private float scrapDropChance = 0.7f;
    [SerializeField] private float overallDropChance = 0.2f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DropLoot(animator.gameObject.transform.position);
    }

    private void DropLoot(Vector3 pos)
    {
        float a = Random.Range(0f, 1f);
        if (a <= overallDropChance)
        {
            if (a <= gelDropChance)
            {
                Instantiate(gelPrefab, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(scrapPrefab, pos, Quaternion.identity);
            }
        }
    }
}
