using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 100;
    public float damage = 30;
    public GameObject dieParticleEnemyHuman1;
    public Transform tr;
    public GameObject chiraliumBig;
    public GameObject chiraliumMedium;
    public GameObject chiraliumSmall;
    public Collider2D enemyCol;
    public float visibleRange = 5f;

    



    public Animator animEnemy;

    public GameObject playerObject;

    private int chiralNumber = 1;
    


    // Start is called before the first frame update
    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Dissapear();
        //Debug.Log(playerObject.transform.position.x - gameObject.transform.position.x);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            enemyCol.enabled = !enemyCol.enabled;
            Die();
        }
    }

    
    void Die()
    {
        
        chiralNumber = Random.Range(1, 4);
        ChiralDrop();
        animEnemy.SetBool("death", true);
        Instantiate(dieParticleEnemyHuman1, new Vector2(tr.position.x, tr.position.y - 3f), dieParticleEnemyHuman1.transform.rotation);


        
    }

    void Dissapear()
    {
        if (Input.GetButton("Ctr"))
        {
            animEnemy.SetBool("crouch", true);
        }
        else
            animEnemy.SetBool("crouch", false);

        if (Input.GetButton("Horizontal"))
        {
            animEnemy.SetBool("moving", true);
        }
        else
            animEnemy.SetBool("moving", false);

        if ((Mathf.Abs(playerObject.transform.position.x - gameObject.transform.position.x)) <= visibleRange)
        {
            animEnemy.SetBool("visible", true);

        }
        else
        {
            animEnemy.SetBool("visible", false);
        }
    }

    void ChiralDrop()
    {
        switch(chiralNumber)
        {
            case 3:
                Instantiate(chiraliumBig, tr.position, tr.transform.rotation);
                break;
            case 2:
                Instantiate(chiraliumMedium, tr.position, tr.transform.rotation);
                break;
            case 1:
                Instantiate(chiraliumSmall, tr.position, tr.transform.rotation);
                break;
        }
    }




}
