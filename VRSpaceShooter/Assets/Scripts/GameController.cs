using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemyShip;
    public float SpawnDistance=20;
    Transform PlayerTransform;
    public float SpawnTime;
    public float WaveTime;

    int fibbo1 = 0, fibbo2 = 1, fibbo3;
    void Start()
    {

        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(SpawnEnemySHips());
    }

    IEnumerator SpawnEnemySHips()
    {
        while (true)
        {
            fibbo3 = fibbo1 + fibbo2;

            for (int i = 1; i <= fibbo3; ++i)
            {
                int xpos = Random.Range(-100, 100);
                Vector3 spawnPoint = PlayerTransform.position + new Vector3(xpos, 0, SpawnDistance);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemyShip, spawnPoint, spawnRotation);

                fibbo1 = fibbo2;
                fibbo2 = fibbo3;

                yield return new WaitForSeconds(SpawnTime);
            }
            yield return new WaitForSeconds(WaveTime);
        }
    }
}
