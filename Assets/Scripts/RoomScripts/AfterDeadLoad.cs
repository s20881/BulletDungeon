using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AfterDeadLoad : MonoBehaviour
{
    [SerializeField] GameData gameData;
    private GameObject objectToFollow;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        StartCoroutine(LoadAfter());
        objectToFollow = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
    }
    IEnumerator LoadAfter()
    {
        while (true)
        {
            if (gameData.isDead==true)
            {
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(3.5f);
                gameData.isDead = false;
                SceneManager.LoadScene("Lobby");
                break;
            }
            yield return new WaitForSeconds(0);
        }
    }
}
