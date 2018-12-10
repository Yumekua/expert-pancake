using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayonLaserPower : Entity
{
    void Start()
    {
        StartCoroutine(AfterTime(2));
    }

    IEnumerator AfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
