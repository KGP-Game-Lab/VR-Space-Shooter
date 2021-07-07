using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShip : MonoBehaviour {

    public int LifeTime;
    public int Health;
	void Start () {
        Debug.Log("Automatic Destroy");
        Destroy(gameObject, LifeTime);
	}
	

	public void ReduceHealth()
    {
        Health--;
        if (Health < 0)
        {
            Debug.Log("Shoot Destroy");
            Destroy(gameObject);
        }
        
    }
}
