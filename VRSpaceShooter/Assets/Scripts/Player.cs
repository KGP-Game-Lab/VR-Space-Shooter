using UnityEngine;

public class Player : MonoBehaviour {

    Camera cam;
    [SerializeField]
    GameObject SpaceShip;
    public float speed;

    void Start () {
        cam = Camera.main;
	}
	
	void FixedUpdate ()
    {
        
        Vector3 f = cam.transform.localEulerAngles;
        //Debug.Log(f);
        this.transform.localEulerAngles = new Vector3(0,0,f.z);
        cam.transform.localEulerAngles = new Vector3(f.z, f.y, 0);

        if (f.z < 45.0 && f.z > 1.0)
            transform.position = transform.position + new Vector3(Time.deltaTime*-1, 0, Time.deltaTime) * speed;
        else if (f.z > 325)
            transform.position = transform.position + new Vector3(Time.deltaTime, 0, Time.deltaTime) * speed;
        else
            transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
        
    }
}
