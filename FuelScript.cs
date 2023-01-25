using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            NewPlayer.Instance.fuel += 3;
            gameObject.SetActive(false);
        }
    }

}
