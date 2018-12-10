using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {

    float score = 0f;
    float timeleft = 0.001f;

    // Use this for initialization
    void Start () {
        transform.GetComponent<Text>().text = score.ToString("f1");
    }
	
	// Update is called once per frame
	void Update () {

        timeleft -= Time.deltaTime;

        if (timeleft <= 0.0)
        {
            score += 0.01f;
            transform.GetComponent<Text>().text = score.ToString("f1");
            timeleft = 0.001f;
        }
    }
}
