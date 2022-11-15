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
        if (objectToFollow ?? false)
            transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
    }
    IEnumerator LoadAfter()
    {
        while (true)
        {
            if (gameData.isDead==true)
            {
                //Przwyrócenie poziomu trudnoœci gry po œmierci gracza
                gameData.level -= (gameData.bossMeter * 0.15f);
                gameData.levelenem += (gameData.bossMeter * 0.15f);
                //Zresetowanie danych gry z GameData oraz za³¹dowanie lobby po œmierci
                gameData.bossMeter = 0;
                gameData.isbossroom = false;
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(3.0f);
                gameData.isDead = false;
                SceneManager.LoadScene("Lobby");
                break;
            }
            yield return new WaitForSeconds(0);
        }
    }
}
