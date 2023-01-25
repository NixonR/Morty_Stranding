using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplashSpawning : PhysicsObject
{
    float lifetime = 10f;
    [SerializeField] float waitTime = 2f;
    [SerializeField] float fastWaitTime = 0.6f;
    [SerializeField] GameObject enemySplash;
    [SerializeField] Transform spawn;
    [SerializeField, Range(0f, 10f)] float moveSpeedX = 1f;
    [SerializeField] float moveSpeedWithDirectionX;
    [SerializeField] Transform player;
    [SerializeField] bool changeDirection = false;

    [Header("Coroutines info")]
    [SerializeField] bool coroutineStarting = false;
    [SerializeField] bool fastCoroutineStarting = false;

    [Header("Stun Effect")]
    [SerializeField] float stunEffectTime = 6f;
    [SerializeField] bool active = false;
    float basicValue;
    [SerializeField] float fastStepDistance = 4f;
    bool afterFastSpeedBool = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (player.position.x < gameObject.transform.position.x)
        {
            moveSpeedWithDirectionX = moveSpeedX * -1;
        }
        else
            moveSpeedWithDirectionX = moveSpeedX;

        basicValue = moveSpeedWithDirectionX;


        StartCoroutine(DestroySpawner(lifetime));
        StartCoroutine(WaitAndPrint(waitTime));
        coroutineStarting = true;


    }

    // Update is called once per frame
    void Update()
    {

        PeeAttack();

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeedWithDirectionX, targetVelocity.y);

        ChangeSpeedOfMonsterSpawner();

        ChangeCoroutineTypeToSlow();

        ChangeDirection();










    }

    private IEnumerator SlowDownWithPee(float stunEffectTime)
    {
        while (true)
        {
            active = true;

            yield return new WaitForSeconds(stunEffectTime);

            active = false;
            Debug.Log("END OF SLOWDOWNWITHPEEE");
            yield break;
            //moveSpeedWithDirectionX = Mathf.Abs(moveSpeedWithDirectionX);

        }
    }

    private IEnumerator DestroySpawner(float lifetime)
    {
        while (true)
        {
            yield return new WaitForSeconds(lifetime);

            //HERE INSERT DEATH SOUND WHEN ADDING SOUND TO THE GAME++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(enemySplash, spawn.position, spawn.transform.rotation);
        }

    }
    private IEnumerator FasterWaitAndPrint(float fastWaitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(fastWaitTime);
            Instantiate(enemySplash, spawn.position, spawn.transform.rotation);
        }

    }

    void PeeAttack()
    {
        if (Input.GetButtonDown("Fire2") && Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) > 4f)
        {
            StartCoroutine(SlowDownWithPee(stunEffectTime));
        }

        if (active == true)
        {
            moveSpeedWithDirectionX *= -1f;
        }
    }


    void ChangeDirection()
    {
        // WHEN SPLASH MONSTER IS CLOSE
        if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) < 4f && Input.GetButton("Ctr") == false && changeDirection == false)
        {


            if (player.position.x < gameObject.transform.position.x)
            {
                moveSpeedX = -4f;

                moveSpeedWithDirectionX = moveSpeedX;
                //changeDirection = true;
                //Debug.Log("IF NUMER 1 1111111111111111111");
                afterFastSpeedBool = true;






            }

            if (player.position.x > gameObject.transform.position.x)
            {
                moveSpeedX = 4f;

                moveSpeedWithDirectionX = 4f;
                //changeDirection = true;
                //Debug.Log("IF NUMER 2222222222222222222222");
                afterFastSpeedBool = true;




            }

            if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) > 1f && changeDirection == true)
            {
                changeDirection = false;
            }

            if (coroutineStarting == true)
            {

                StopCoroutine(WaitAndPrint(waitTime));
                coroutineStarting = false;

            }

            if (fastCoroutineStarting == false)
            {
                StartCoroutine(FasterWaitAndPrint(fastWaitTime));
                fastCoroutineStarting = true;

            }

        }
        else if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) > fastStepDistance && afterFastSpeedBool == true)
        {
            moveSpeedX = 1f;
            afterFastSpeedBool = false;
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                moveSpeedWithDirectionX = moveSpeedX;

            }
            else
            {
                moveSpeedWithDirectionX = -moveSpeedX;

                //Debug.Log("UGA BUGA");
            }

        }


    }

    void ChangeSpeedOfMonsterSpawner()
    {

    }

    //IF SPLASH MONSTER IS FAR AWAY
    void ChangeCoroutineTypeToSlow()
    {
        if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) > 4f)
        {

            if (fastCoroutineStarting == true)
            {
                StopAllCoroutines();
                fastCoroutineStarting = false;
                //Debug.Log("FAST CORO END");

            }

            if (coroutineStarting == false)
            {
                StartCoroutine(DestroySpawner(lifetime));
                StartCoroutine(WaitAndPrint(waitTime));
                //Debug.Log("AFTER CLOSE SLOW DOWN");
                coroutineStarting = true;
                //Debug.Log("SLOWDOWN");

            }
        }
    }
}
