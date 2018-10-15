using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemyShip;
    public float SpawnDistance;
    public int SpawnhalfWidth;
    Transform PlayerTransform;
    public float SpawnTime;
    public float WaveTime;

    public GameObject[] BulletSpawnPoint;
    public GameObject Bullet;
    public float BulletSpeed;
    bool bulletIsShot = false;
    GameObject bullet1, bullet2;
    int fibbo1 = 0, fibbo2 = 1, fibbo3;
    void Start()
    {
        //Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + new Vector3(0, 0, 100),Color.red);
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(SpawnEnemySHips());
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown ("Fire1"))
        {
            Shoot();
        }
    }

    IEnumerator SpawnEnemySHips()
    {
        while (true)
        {
            fibbo3 = fibbo1 + fibbo2;

            for (int i = 1; i <= fibbo3; ++i)
            {
                int xpos = Random.Range(-1*SpawnhalfWidth, SpawnhalfWidth);
                Vector3 spawnPoint = PlayerTransform.position + new Vector3(xpos, -1, SpawnDistance);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemyShip, spawnPoint, spawnRotation);

                fibbo1 = fibbo2;
                fibbo2 = fibbo3;

                yield return new WaitForSeconds(SpawnTime);
            }
            yield return new WaitForSeconds(WaveTime);
        }
    }

    

    public void Shoot()
    {
        //Debug.Log("Shott Click!!!");
        Camera cam = Camera.main;
        RaycastHit hit;
        Debug.DrawLine(BulletSpawnPoint[0].transform.position, BulletSpawnPoint[0].transform.position + new Vector3(0, 0, 100), Color.red, 10);
        Debug.DrawLine(BulletSpawnPoint[1].transform.position, BulletSpawnPoint[1].transform.position + new Vector3(0, 0, 100), Color.red, 10);
        if (Physics.Raycast(BulletSpawnPoint[0].transform.position, BulletSpawnPoint[0].transform.forward, out hit,Mathf.Infinity))
        {

            hit.collider.gameObject.GetComponentInParent<DestroyShip>().ReduceHealth();
        }
        if (Physics.Raycast(BulletSpawnPoint[1].transform.position, BulletSpawnPoint[1].transform.forward, out hit,Mathf.Infinity))
        {
            hit.collider.gameObject.GetComponentInParent<DestroyShip>().ReduceHealth();
        }
    }
   
}
