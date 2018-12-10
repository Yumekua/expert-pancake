using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour {

    public Camera cam;
    Vector3 screenPos;
    Vector3 screenPos2;

    public GameObject target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        screenPos = cam.WorldToScreenPoint(target.transform.position);
        screenPos2 = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, screenPos.z-7));

        transform.position = screenPos2;
       // transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.y);

    }
}
