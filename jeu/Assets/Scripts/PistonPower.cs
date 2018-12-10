using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonPower : Entity
{

    public GameObject Piston;
    private bool AlreadyDown;

	void Start ()
    {
        AlreadyDown = false;
	}
	

	void Update ()
    {
        GameManager.state.CallOnEnabled();
	}

    public override void OnEnabled()
    {
        base.OnEnabled();
        if (Piston.transform.position.y > -2.27f)
        {
            if (!AlreadyDown)
            {
                transform.Translate(new Vector3(0, 0.1f, 0) * -1 * 3);
            }
            
        }
        if (Piston.transform.position.y <= -2.27f)
        {
            AlreadyDown = true;
            StartCoroutine(AfterTime(2));
            GameManager.state.CallDestroy();
        }
        
        
    }
    IEnumerator AfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        transform.Translate(new Vector3(0, 0.1f, 0) * 0.5f);
    }
}
