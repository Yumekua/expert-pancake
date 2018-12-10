using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public virtual void OnEnabled()
    {

    }

    public void Destroy()
    {
        StartCoroutine(destroy(4));
    }

    private void OnEnable()
    {
        GameManager.state.RegisterEntity(this);
    }

    private void OnDisable()
    {
        GameManager.state.UnregisterEntity(this);
    }

    IEnumerator destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
