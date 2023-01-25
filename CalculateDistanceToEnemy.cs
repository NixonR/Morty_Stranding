using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistanceToEnemy : MonoBehaviour
{
    string nameCloseObject;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public Collider2D findClosestObject(string nameCloseObj)
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, 500f);
        Collider2D closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (Collider2D collider2D in colliderArray)
        {
            if (collider2D.CompareTag(nameCloseObj))
            {
                Vector2 diff = collider2D.transform.position - position;

                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = collider2D;
                    distance = curDistance;
                }
            }



        }
        return closest;
    }


}
