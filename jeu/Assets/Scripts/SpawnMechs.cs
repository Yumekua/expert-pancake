using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMechs : MonoBehaviour
{

    public GameObject[] mech;
    private int ReturnValue;
    public GameObject Plafond;
    public GameObject Gauche;
    public GameObject Droite;
    public GameObject Centre;

    void Start ()
    {
        StartCoroutine(Generate(2));
    }
	
	void Update ()
    {
		
	}

    private void GenerateMechs ()
    {
        ReturnValue = Random.Range(0, mech.Length);

        Instantiate(mech[ReturnValue], new Vector3(Random.Range(Gauche.transform.position.x, Droite.transform.position.x), Centre.transform.position.y, Centre.transform.position.z), mech[ReturnValue].transform.rotation);
    }

    IEnumerator Generate(float time)
        {
            for (int i = 0; i < 100; i++)
            {
                yield return new WaitForSeconds(time);
                GenerateMechs();
                
            }

        }
}
