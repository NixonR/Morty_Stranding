using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyIfCloseItsAggresive : MonoBehaviour
{
    AIPath aiPath;
    MortyBreathing mrBreathing;
    Rigidbody2D rb2D;
    GameObject playerObject;
    AIDestinationSetter aiDestinationSetter;


    public int interpolationFramesCount = 45;
    int elapsedFrames = 0;

    // Start is called before the first frame update
    void Start()
    {
        aiPath = gameObject.GetComponent<AIPath>();
        mrBreathing = GameObject.FindGameObjectWithTag("Player").GetComponent<MortyBreathing>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        aiDestinationSetter = gameObject.GetComponent<AIDestinationSetter>();


    }

    // Update is called once per frame
    void Update()
    {

        Patrol();
    }

    void Patrol()
    {
        if (Mathf.Abs(playerObject.transform.position.x - gameObject.transform.position.x) > 14f)
        {
            gameObject.GetComponent<Patrol>().enabled = true;
            //aiPath.enabled = false;
            aiDestinationSetter.enabled = false;
        }
        else
        {
            gameObject.GetComponent<Patrol>().enabled = false;
            //aiPath.enabled = true;
            aiDestinationSetter.enabled = true;
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && mrBreathing.mortyHoldBreath == false)
        {
            aiPath.maxSpeed = 1f;
            rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            //Debug.Log("CLOSE ENOUGH");
            

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            
            aiPath.maxSpeed = 0.5f;
            rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        }

    }
}
