using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPower : Entity
{
    public GameObject RayonLaser;
    public GameObject Laser;
    private bool UnSeulLaser = false;

    void Update()
    {
        GameManager.state.CallOnEnabled();
    }

    public override void OnEnabled()
    {
        base.OnEnabled();
        if (Laser.transform.position.y > -0.15f)
        {
            transform.Translate(new Vector3(0, 0.1f, 0) * -1 * 1);
        }
        StartCoroutine(GenerateRayon(2));
        if (Laser.transform.position.y <= -0.15f)
        {
            StartCoroutine(AfterTime(5));
            GameManager.state.CallDestroy();
        }

    }

    IEnumerator AfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        transform.Translate(new Vector3(0, 0.1f, 0) * 0.5f);
    }

    IEnumerator GenerateRayon(float time)
    {
        yield return new WaitForSeconds(time);
        if (!UnSeulLaser)
        {
            UnSeulLaser = true;
            for (int i = 0; i < 1; i++)
            {
                Instantiate(RayonLaser, new Vector3(Laser.transform.position.x, Laser.transform.position.y + -0.54f, Laser.transform.position.z), RayonLaser.transform.rotation);
            }
        }
        
    }
}
