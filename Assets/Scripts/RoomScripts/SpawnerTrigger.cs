using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    //zmienne pomocnicze
    public bool sp;
    public bool wv;
    public bool firsttrig=true;
    public GameObject u;
    public GameObject d;
    public GameObject r;
    public GameObject l;
    public GameObject minimaphide;
    public bool specialRoomtf;
    public GameObject enem;
    private int ex;
    //gamedata i listy wejsc
    [SerializeField] GameData gameData;
    private  List<GameObject> entrUD;
    private  List<GameObject> doorsLR;
    private List<GameObject> entrLR;
    private List<GameObject> doorsUD;

    private void Start()//ustalenie które wejscia mają się otwierać
    {
        entrUD = new List<GameObject>();
        doorsLR = new List<GameObject>();
        entrLR = new List<GameObject>();
        doorsUD = new List<GameObject>();
        entrUD.Add(u);
        entrUD.Add(d);
        entrLR.Add(l);
        entrLR.Add(r);
        ex = 1;
        foreach (GameObject o in entrUD)
        {           
            if (!o.activeSelf)
            {
                doorsUD.Add(o);
                
                o.transform.position =new Vector3(o.transform.position.x + 3.0f, o.transform.position.y, o.transform.position.z);
            }
        }
        foreach (GameObject o in entrLR)
        {
            if (!o.activeSelf)
            {
                doorsLR.Add(o);

                o.transform.position = new Vector3(o.transform.position.x , o.transform.position.y+ 3.0f, o.transform.position.z);
            }
        }
        sp = false;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)//aktywacja trigera aktualizacja gamedata
    {
        if (collision.CompareTag("Player"))
        {
            sp = true;
            if (firsttrig)
            {
                enem.GetComponent<EnemyMovement>().currentDestination = (Vector2)transform.position; // zmiana punktu odniesienia przeciwników do aktualnego pokoju
                gameData.spawnMeter--;
                firsttrig = false;
                minimaphide.SetActive(false);
                foreach (GameObject o in doorsUD)//zamykanie pomieszczeń
                {
                    Vector3 v = new Vector3(o.transform.position.x - 3.0f, o.transform.position.y, o.transform.position.z);
                    StartCoroutine(MoveOverSeconds(o, v, 1f));
                }
                foreach (GameObject o in doorsLR)//zamykanie pomieszczeń
                {
                    Vector3 v = new Vector3(o.transform.position.x , o.transform.position.y - 3.0f, o.transform.position.z);
                    StartCoroutine(MoveOverSeconds(o, v, 1f));
                }

            }          
        }
    }
    //otwieranie/zamykanie pomieszczen
    private void Update()
    {
        
        if (!specialRoomtf && sp)
        {
            if (gameData.enemMeter == 8)
                ex = 0;
            if (gameData.enemMeter == 0 && ex < 1)
            {
                foreach (GameObject o in doorsUD)
                {
                    Vector3 v = new Vector3(o.transform.position.x + 3.0f, o.transform.position.y, o.transform.position.z);
                    StartCoroutine(MoveOverSeconds(o, v, 1f));
                }
                foreach (GameObject o in doorsLR)
                {
                    Vector3 v = new Vector3(o.transform.position.x , o.transform.position.y + 3.0f, o.transform.position.z);
                    StartCoroutine(MoveOverSeconds(o, v, 1f));
                }
                ex += 1;
            }
            else
            {
                foreach (GameObject o in doorsUD)
                {
                    o.SetActive(true);

                }
                foreach (GameObject o in doorsLR)
                {
                    o.SetActive(true);

                }
            }
        }
                
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }

}
