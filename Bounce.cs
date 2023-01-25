using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bouncePower = 10f;

    NewPlayer newPlayer;

    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<NewPlayer>())
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);
            
            Debug.Log("bouncing");
        }
        
        //&& collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < 10f
    }
}
