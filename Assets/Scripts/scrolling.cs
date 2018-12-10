using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour {

    [Range(0, 10)]
    public float vitesse = 4.5f;

    public Rigidbody2D rb;
    public Transform player;
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();

    }
	
	
	void Update () {
        rb.velocity = new Vector3(vitesse, 0, 0);
        transform.position = new Vector3(transform.position.x, player.position.y + 6.5f, transform.position.z);
    }
}
