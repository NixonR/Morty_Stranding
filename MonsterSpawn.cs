using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] GameObject monsterChase;
    GameObject playerObject;
    bool isClose;
    float timeUp = 0f;
    float baseX;
    float baseY;



    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        baseX = gameObject.transform.position.x;
        baseY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        MonsterSpawner();
        
    }


    void MonsterSpawner()
    {
        if (Mathf.Abs(playerObject.transform.position.x - gameObject.transform.position.x) < 10f && Input.GetButton("Ctr") == false && isClose == false)
        {
            Instantiate(monsterChase, transform.position, transform.rotation);
            isClose = true;
        }
        else if (Mathf.Abs(playerObject.transform.position.x - gameObject.transform.position.x) > 10f)
        {
            isClose = false;
        }
        else if (Mathf.Abs(playerObject.transform.position.x - gameObject.transform.position.x) < 10f && Input.GetButton("Ctr") == false )
        {
            timeUp += Time.deltaTime;
            //Debug.Log(timeUp);
            if(timeUp > 1f)
            {
                timeUp = 0f;
                Instantiate(monsterChase, transform.position, transform.rotation);
            }
        }


    }

    
}
