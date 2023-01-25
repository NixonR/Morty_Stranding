using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOfEnemy : MonoBehaviour
{

    [SerializeField] GameObject enemyObj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyObj == null)
        {
            Destroy(gameObject);
        }
    }
}
