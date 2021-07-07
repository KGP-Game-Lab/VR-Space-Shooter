using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {

    float x, y;
	// Use this for initialization
	void Start () {
        x = transform.rotation.x;
        y = transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.rotation = new Quaternion(x, y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);

	}
}
