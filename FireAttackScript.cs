using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttackScript : MonoBehaviour
{
    GameObject redPutin;
    public float thrust = 3f;
    Collider cole;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void OnTriggerEnter2D(Collider2D col)
    {
       
        
            if (col.gameObject.GetComponent<EnemyScript>())
            {
                col.gameObject.GetComponent<EnemyScript>().HP -= 25;
                StartCoroutine(RedPutin(col));
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            }
        
        
    }

    public IEnumerator RedPutin(Collider2D col)
    {

        col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log("COLOR RED");
        yield return new WaitForSeconds(0.1f);
        col.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public IEnumerator PutinAlive()
    {
        redPutin.gameObject.SetActive(false);
        Debug.Log("Korutyna ssie");
        
        yield return new WaitForSeconds(0.5f);
        
    }

    
}
