using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float dash = 0;
    float backDash = 0;
    float idle = 0;

    public bool enter = false;
    public bool stop = false;

    [Range(-20, 20)]
    public float vitesse = 1.1f;

    public Rigidbody2D rb;
    public float waitTime = 0.1f;

    private Vector2 startPosition;
    private Vector2 endPosition;

    public float swipeDistanceThreshold = 50;

    public Camera cam;
    Vector2 screenPos;

    bool tapisNonRoulant;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        dash = vitesse + 10f;
        backDash =  -10;
        idle = vitesse;
    }

	void Update ()
    {
        screenPos = cam.WorldToScreenPoint(transform.position);
        DeplacementTouche();

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            SautTouche();
        }

        Tapis();

        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Stockage du point de départ
                    startPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                    // Stockage du point de fin
                    endPosition = touch.position;
                    Deplacement(startPosition, endPosition);
                    Saut(startPosition, endPosition);
                    break;
            }
        }
    }

    private void Deplacement(Vector2 start, Vector2 end)
    {
        if (Vector2.Distance(start, end) > swipeDistanceThreshold && start.x < end.x) // droite Input.GetKeyDown(KeyCode.RightArrow)
        {
            vitesse = dash * 2;
            StartCoroutine(Waitmove());
        }
        else if (Vector2.Distance(start, end) > swipeDistanceThreshold && start.x > end.x) // gauche Input.GetKeyDown(KeyCode.LeftArrow)
        {
            vitesse = backDash * 2;
            StartCoroutine(Waitmove());
        }
    }

    private void DeplacementTouche()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) // droite
        {
            vitesse = dash * 2;
            StartCoroutine(Waitmove());
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) // gauche 
        {
            vitesse = backDash * 2;
            StartCoroutine(Waitmove());
        }
    }

    private void Tapis()
    {
        if (enter)
        {
            rb.velocity = new Vector3(vitesse, rb.velocity.y, 0);
            stop = false;
        }
    }

    private void Saut(Vector2 start, Vector2 end)
    {
        if (( Vector2.Distance(start, end) < swipeDistanceThreshold && Input.mousePosition.x > screenPos.x) && (enter == true || tapisNonRoulant == true)) /*Input.GetMouseButtonUp(0)*/
        {
            rb.AddForce(new Vector2(100 * 1.25f, 400f * 1.25f));
            enter = false;
        }

        if (( Vector2.Distance(start, end) < swipeDistanceThreshold  && Input.mousePosition.x <= screenPos.x) && (enter == true || tapisNonRoulant == true)) /*(Input.GetMouseButtonUp(0)*/
        {
            rb.AddForce(new Vector2(-100 * 1.25f, 400f * 1.25f));
            enter = false;
        }
    }

    private void SautTouche()
    {
        if ((Input.GetMouseButtonDown(0) && Input.mousePosition.x > screenPos.x) && (enter == true || tapisNonRoulant == true)) 
        {
            rb.AddForce(new Vector2(100 * 1.25f, 400f * 1.25f));
            enter = false;
        }

        if ((Input.GetMouseButtonDown(0) && Input.mousePosition.x <= screenPos.x) && (enter == true || tapisNonRoulant == true)) 
        {
            rb.AddForce(new Vector2(-100 * 1.25f, 400f * 1.25f));
            enter = false;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tapis roulant")
        {
            enter = true;
        }

        if (collision.gameObject.tag == "simpleSol")
        {
            tapisNonRoulant = true;
        }

        if (collision.gameObject.tag == "piston")
        {
            Debug.Log("deathPiston");
        }

        if (collision.gameObject.tag == "death")
        { 
            Debug.Log("death");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tapis roulant")
        {
            enter = false;
        }

        if (collision.gameObject.tag == "simpleSol")
        {
            tapisNonRoulant = false;
        }
    }

    IEnumerator Waitmove ()
    {
        yield return new WaitForSeconds(waitTime);
        vitesse = idle;
    }
}
