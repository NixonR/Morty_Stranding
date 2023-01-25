using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform bulletPoint;
    public GameObject shootParticle;
    public GameObject shootParticle2;
    public Rigidbody2D rb;
    public float speed = 20;
    [SerializeField] private float damage = 35;

    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        bulletObject = GameObject.FindGameObjectWithTag("bullet");
        bulletPoint = bulletObject.transform;
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if(enemy!= null)
        {
        enemy.TakeDamage(damage);
        }
        Instantiate(shootParticle, transform.position, transform.rotation );
        Instantiate(shootParticle2, transform.position, transform.rotation);
        Debug.Log(hitInfo);
        Destroy(gameObject);

    }
}
