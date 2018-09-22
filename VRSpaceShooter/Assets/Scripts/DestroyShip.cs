using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShip : MonoBehaviour {

    public int LifeTime;
	void Start () {
        Destroy(gameObject, LifeTime);
	}
	
	
}
