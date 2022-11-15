using UnityEngine;
using System.Collections;

public class MusicBG : MonoBehaviour
{
	public AudioSource audios;
	[SerializeField] GameData gameData;
	public void Awake()
	{
		audios.volume = gameData.VolumeVal / 4;
        StartCoroutine(silentmus());
    }
	public void Update()
    {
        audios.volume = gameData.VolumeVal;
    }
	IEnumerator silentmus()
    {
        while (true)
        {
            if (gameData.isDead == true)
            {
                for(int i=0; i<5; i++)
                {
                    audios.pitch -=0.2f;
                    yield return new WaitForSeconds(0.6f);
                }    
                break;
            }
            yield return new WaitForSeconds(0);
        }
    }

}