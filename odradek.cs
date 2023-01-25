using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class odradek : MonoBehaviour
{
    public Transform playerTransform;
    public Animator anim;
    public Transform enemyTransform;
    public CalculateDistanceToEnemy clc;
    private float turningScale = 1.6f;
    MortyController mc;
    public GameObject playerGO;
    public Animator enemyAnim;
    Collider2D eGO;
    




    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("odradek").GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        //GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        mc = playerGO.GetComponent<MortyController>();
        
        enemyAnim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            //Debug.Log(clc.findClosestObject().tag == "Enemy");
            //eGO = clc.findClosestObject().tag == "Enemy";
            eGO = clc.findClosestObject("Enemy");
            enemyTransform = eGO.gameObject.GetComponent<Transform>();

            enemyAnim = clc.findClosestObject("Enemy").GetComponent<Animator>();
        }

        if(GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            anim.SetBool("monster", true);
            ShowMonster();

        }

        else
        {
            anim.SetBool("monster", false);
        }
        MortyRotationOdradek();
        TurnOdradek();



    }





    void ShowMonster()
    {
        if ((Mathf.Abs(playerTransform.position.x - enemyTransform.position.x)) <= 15f && (Mathf.Abs(playerTransform.position.x - enemyTransform.position.x)) >= 10f )
        {
            anim.SetBool("basic", true);
        }
        else
        {
            anim.SetBool("basic", false);
        }

        if ((Mathf.Abs(playerTransform.position.x - enemyTransform.position.x)) < 10f && (Mathf.Abs(playerTransform.position.x - enemyTransform.position.x)) > 5f )
        {
            anim.SetBool("yellow", true);
        }
        else
        {
            anim.SetBool("yellow", false);
        }

        if ((Mathf.Abs(playerTransform.position.x - enemyTransform.position.x)) <= 5f && (Mathf.Abs(playerTransform.position.x - enemyTransform.position.x)) > 0.1f )
        {
            anim.SetBool("red", true);
        }
        else
        {
            anim.SetBool("red", false);
        }

        
    }

    void TurnOdradek()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length > 0 && enemyTransform != null)
        {
            if (playerTransform.position.x < enemyTransform.position.x)
            {
                transform.localScale = new Vector2(turningScale, 1.6f);

            }

            else if (playerTransform.position.x > enemyTransform.position.x)
            {
                transform.localScale = new Vector2(-turningScale, 1.6f);
            }
            else
            {
                transform.localScale = transform.localScale;
            }
        }
        
    }
    void MortyRotationOdradek()
    {
        if (mc.facingRight == false)
        {
            turningScale = -1.6f;
        }
        else
        {
            turningScale = 1.6f;
        }
    }
}
