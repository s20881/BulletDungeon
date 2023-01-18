using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropper : StateMachineBehaviour
{
    [SerializeField] private GameObject gelPrefab;
    [SerializeField] private GameObject scrapPrefab;
    [SerializeField] private GameObject gunpowderPrefab;
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private float gelDropChance = 0.3f;
    [SerializeField] private float scrapDropChance = 0.7f;
    [SerializeField] private float gunpowderDropChance = 0.1f;
    [SerializeField] private float overallDropChance = 0.2f;
    [SerializeField] private float grenadeDropChance = 0.025f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DropLoot(animator.gameObject.transform.position);
    }

    private void DropLoot(Vector3 pos)
    {
        float a = Random.Range(0f, 1f);
        if (a <= overallDropChance)
        {
            float b = Random.Range(0f, 1f);
            if (b <= scrapDropChance)
            {
                Instantiate(scrapPrefab, pos, Quaternion.identity);
                if(b <= gelDropChance)
                {
                    Instantiate(gelPrefab, pos, Quaternion.identity);
                    if(b <= gunpowderDropChance)
                    {
                        Instantiate(gunpowderPrefab, pos, Quaternion.identity);
                    }
                }
            }
        }
        float grenadeDrop = Random.Range(0f, 1f);
        if(grenadeDrop <= grenadeDropChance)
        {
            Instantiate(grenadePrefab, pos, Quaternion.identity);
        }
    }
}
